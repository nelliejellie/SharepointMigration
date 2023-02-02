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
    public class JobDataForLotFitRequest
    {
        public readonly IJobDataForLotFitRequestsService _siteService;
        private readonly DynamicsApi _dynamicsApi;

        public JobDataForLotFitRequest(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<IJobDataForLotFitRequestsService>();
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("JobDataForLotFitRequestsFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("jobdataforlotfitrequests", Connection = "AzureWebJobsStorage")] UnitModel myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"JobDataForLotFitRequestsFunction Queue trigger function processed: {myQueueItem}");
                var jobDataModel = Map(myQueueItem);

                var siteRecord = await _siteService.Get(myQueueItem.JobNumber);

                if (siteRecord.Id == null)
                {
                    try
                    {
                        _siteService.Create(jobDataModel.JobNumber, jobDataModel);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }

                }
                else
                {
                    jobDataModel.Id = siteRecord.Id;
                    siteRecord = await _siteService.Update(jobDataModel.JobNumber, jobDataModel);
                }
            }catch(Exception ex) { log.LogError(ex.Message,ex); throw; }
        }

        private JobDataForLotFitRequestsServiceModel Map(UnitModel item)
        {
            Erp.Api.Controllers.ProjectModel project = null;
            if (item.WarehouseId != null)
                project = _dynamicsApi.GetProjects(item.WarehouseId);

            var result = new JobDataForLotFitRequestsServiceModel();
            result.JobNumber = item.JobNumber;
            result.Address = item.StreetAddress;
            result.Block = item.Block;
            result.Elevation =  item.Elevation;
            result.Lot = item.Lot;
            result.Section = item.Section;
            result.LotStatus = item.LotStatusCode;
            result.Plan = item.Plan;
            result.Division = project == null ? "" : project.DivisionName;
            result.Community = project == null ? "" : project.CommunityName;
            result.RegionCity = item.City;
            
            
            return result;
        }
    }
}
