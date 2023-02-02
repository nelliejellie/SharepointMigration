using Erp.Common.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Data;
using SharePointMigration.Model;
using SharePointMigration.Service;
using System;
using System.Threading.Tasks;

namespace SharePointMigration.ProcessingFuntions
{
    public class SubdivisionRequirementsListFunction
    {
        private readonly ISubdivisionRequirementsListService _siteService;
        private readonly DynamicsApi _dynamicsApi;

        public SubdivisionRequirementsListFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<ISubdivisionRequirementsListService>();
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("SubdivisionRequirementsListFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("subdivisionrequirementslist", Connection = "AzureWebJobsStorage")] UnitModel myQueueItem, ILogger log)
        { try{
            log.LogInformation($"SubdivisionRequirementsListFunction Queue trigger function processed: {myQueueItem}");
            var subDivisionModel = Map(myQueueItem);
            if (!string.IsNullOrEmpty(subDivisionModel.Community))
            {
                var siteRecord = await _siteService.Get(subDivisionModel.ProjectNumber);
                if (siteRecord?.Id == null)
                {
                    _siteService.Create(subDivisionModel.ProjectNumber, subDivisionModel);
                }
                else
                {

                    siteRecord = await _siteService.Update(subDivisionModel.ProjectNumber, subDivisionModel);
                }
            }
        }
            catch (Exception ex) { log.LogError(ex.Message, ex); throw; }
        }

        private SubdivisionRequirementsListModel Map(UnitModel item)
        {
            Erp.Api.Controllers.ProjectModel project = null;
            if (item.WarehouseId != null)
                project = _dynamicsApi.GetProjects(item.WarehouseId);

            var result = new SubdivisionRequirementsListModel();

            result.ProjectNumber = item.JobNumber;
           
            result.Community = project == null ? "" : project.CommunityName;
            result.Division = project == null ? "" : project.DivisionName;
            if(project != null)
            {
                result.Active = project.IsActive == true ? "" : "Active";
            }
            
           
            return result;
        }

        //private SubdivisionRequirementsListModel Map(UnitModel item)
        //{
        //    var result = new SubdivisionRequirementsListModel();
        //    return result;
        //}
    }
}
