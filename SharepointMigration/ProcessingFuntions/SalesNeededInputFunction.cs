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
    public class SalesNeededInputFunction
    {
        private readonly ISalesNeedInputService _siteService;
        private readonly DynamicsApi _dynamicsApi;

        public SalesNeededInputFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<ISalesNeedInputService>();
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("SalesNeededInputFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("salesneededinput", Connection = "AzureWebJobsStorage")] ProjectModel myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"SalesNeededInputFunction Queue trigger function processed: {myQueueItem.WarehouseId}");
                var salesandinput = Map(myQueueItem);
                var siteRecord = await _siteService.Get(salesandinput.ProjectNumber);
                if (siteRecord?.ProjectNumber == null)
                {
                    _siteService.Create(salesandinput.ProjectNumber, salesandinput);
                }
                else
                {
                    siteRecord = await _siteService.Update(salesandinput.ProjectNumber, salesandinput);

                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message, ex);   
                throw ex;
            }
           
        }

        private SalesNeedInputModel Map(ProjectModel item)
        {
            Erp.Api.Controllers.ProjectModel project = null;
            
           

            var result  = new SalesNeedInputModel();
            result.ProjectTitle = item.Name;
            result.ProjectNumber = item.WarehouseId;
            result.Division =  item.DivisionName;



            return result;
        }
    }
}