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
    public class SubDivisionSelectionTypeFunction
    {
        private readonly ISubDivisionSelectionTypeService _siteService;
        private readonly DynamicsApi _dynamicsApi;

        public SubDivisionSelectionTypeFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<ISubDivisionSelectionTypeService>();
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("SubdivisionSelectionTypeFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("subdivisionselectiontypetimerfunction", Connection = "AzureWebJobsStorage")] UnitModel myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"SubdivisionSelectionTypeFunction Queue trigger function processed: {myQueueItem}");
                var subDivisionModel = Map(myQueueItem);
                var siteRecord = await _siteService.Get(subDivisionModel.ProjectNumber);
                if (siteRecord.ProjectNumber == null)
                {
                    _siteService.Create(subDivisionModel.ProjectNumber, subDivisionModel);
                }
                else
                {
                    subDivisionModel.Id = siteRecord.Id;
                    siteRecord = await _siteService.Update(subDivisionModel.ProjectNumber, subDivisionModel);
                }
            }catch(Exception ex) { log.LogError(ex.Message, ex); throw; }
        }

        private SubdivisionSelectionTypeModel Map(UnitModel item)
        {
            Erp.Api.Controllers.ProjectModel project = null;
            if (item.WarehouseId != null)
                project = _dynamicsApi.GetProjects(item.WarehouseId);

            var result = new SubdivisionSelectionTypeModel();

            result.ProjectNumber = project == null ? "" : project.Number.ToString();
            result.Community = project == null ? "" : project.CommunityName;
            result.Active = project == null ? "" : "Active";

            return result;
        }
    }
}
