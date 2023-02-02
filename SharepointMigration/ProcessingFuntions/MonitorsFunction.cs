
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Common.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Data;
using SharePointMigration.Model;
using SharePointMigration.Service;

namespace SharePointMigration.ProcessingFuntions
{
    public class MonitorsFunction
    {
        public readonly IMonitorsService _siteService;
        private readonly DynamicsApi _dynamicsApi;

        public MonitorsFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<IMonitorsService>();
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("MonitorsFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("monitors", Connection = "AzureWebJobsStorage")] UnitModel myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"MonitorsFunction Queue trigger function processed: {myQueueItem.JobNumber}");
                var monitorModel = Map(myQueueItem);

                var siteRecord = await _siteService.Get(myQueueItem.JobNumber);

                if (siteRecord.JobNumber == null)
                {
                    _siteService.Create(monitorModel.JobNumber, monitorModel);
                }
                else
                {
                    monitorModel.Id = siteRecord.Id;
                    siteRecord = await _siteService.Update(monitorModel.JobNumber, monitorModel);
                }
            }catch(Exception ex) { log.LogError(ex.Message,ex); throw; }
        }

        private MonitorsModel Map(UnitModel item)
        {
            
            var project = _dynamicsApi.GetProjects(item.WarehouseId);
            var stageOfConstruction = _dynamicsApi.GetStageForMonitor(int.Parse(item.StageId));
            
            var monitorModel = new MonitorsModel();
            
            monitorModel.JobNumber = item.JobNumber;
            monitorModel.Address = item.StreetAddress;
            monitorModel.City = item.City;
            monitorModel.ReleaseDate = item.ReleaseDate;
            monitorModel.Elevation = item.Elevation;
            monitorModel.ProjectName = project == null ? "" : project.Name;
            monitorModel.DivisionName = project == null ? "" : project.DivisionName;
            monitorModel.StageOfConstruction = stageOfConstruction.Description;
            monitorModel.PlanID = item.Plan;
            if (item.CloseDate.HasValue && item.CloseDate > DateTime.Parse("2000-01-01"))
            {
                monitorModel.SalesStatus = "Closed";
            }
            else if(item.CloseDate.HasValue && item.SaleDate.HasValue)
            {
                monitorModel.SalesStatus = "Sold";
            }
            else
            {
                monitorModel.SalesStatus = "N/A";
            }
            
            return monitorModel;
        }

    }
}
