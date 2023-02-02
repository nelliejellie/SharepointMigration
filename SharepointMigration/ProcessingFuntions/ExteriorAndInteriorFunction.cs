using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class ExteriorAndInteriorFunction
    {
        public readonly IExteriorandInteriorSelectionsService _siteService;
        private readonly DynamicsApi _dynamicsApi;

        public ExteriorAndInteriorFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<IExteriorandInteriorSelectionsService>();
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("ExteriorAndInteriorFunction")]
        public async Task RunAsync([QueueTrigger("exteriorandinteriorselections", Connection = "AzureWebJobsStorage")] UnitModel myQueueItem, ILogger log)
        {
<<<<<<< HEAD
            log.LogInformation($"ExteriorAndInteriorFunction Queue trigger function processed: {myQueueItem.JobNumber}");
            var extAndIntModel = Map(myQueueItem);

            var siteRecord = await _siteService.Get(extAndIntModel.ProjectNumber);

            if (siteRecord.ProjectNumber == null)
=======
            try
>>>>>>> cb5b7334d3c485f06631871b888da0a68fc6858f
            {
                log.LogInformation($"ExteriorAndInteriorFunction Queue trigger function processed: {myQueueItem}");
                var extAndIntModel = Map(myQueueItem);
                if (!string.IsNullOrEmpty(extAndIntModel?.ProjectNumber))
                {
                    var siteRecord = await _siteService.Get(extAndIntModel.ProjectNumber);

                    if (siteRecord?.ProjectNumber == null)
                    {
                        _siteService.Create(extAndIntModel.ProjectNumber, extAndIntModel);
                    }
                    else
                    {
                        siteRecord = await _siteService.Update(extAndIntModel.ProjectNumber, extAndIntModel);
                    }
                }
                else { log.LogInformation("Project number is null", extAndIntModel); }
            }
            catch(Exception ex) { 
                log.LogError(ex.Message, ex);
                throw ex; }
        }


        private ExteriorandInteriorSelectionsModel Map(UnitModel item)
        {
            try
            {
                //Erp.Api.Controllers.ProjectModel project = null;
                //if(item.WarehouseId != null)
                //   project = _dynamicsApi.GetProjects(item.WarehouseId);

                var result = new ExteriorandInteriorSelectionsModel();

<<<<<<< HEAD
            result.ProjectNumber = item.JobNumber;
            result.City = item.City;
            result.Address = item.StreetAddress;
            result.Plan = item.Plan;
            result.Elevation = item.Elevation;
            //result.DateSold = item.SaleDate;
            //result.ReleaseDate = item.ReleaseDate;
            //result.LotStatus = item.LotStatusCode;
            result.Job = item.JobNumber;
            //result.Community = project == null ? "" : project.CommunityName;
            //result.ProjectNumber = project == null ? "" : project.Number.ToString();
            //result.Division = project == null ? "" : project.DivisionName;
=======
                result.ProjectNumber = item.JobNumber;
                result.City = item.City;
                result.Address = item.StreetAddress;
                result.Plan = item.Plan;
                result.Elevation = item.Elevation;
                result.DateSold = item.SaleDate?.ToString("dd mm yyyy");
                //result.ReleaseDate = Convert.ToDateTime(item.ReleaseDate);
                result.LotStatus = item.LotStatusCode;
                result.Job = item.JobNumber;
                //result.Community = project == null ? "" : project.CommunityName;
                //result.ProjectNumber = project == null ? "" : project.Number.ToString();
                //result.Division = project == null ? "" : project.DivisionName;
>>>>>>> cb5b7334d3c485f06631871b888da0a68fc6858f


                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
