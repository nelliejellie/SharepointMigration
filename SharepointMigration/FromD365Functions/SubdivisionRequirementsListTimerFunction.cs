using Erp.Api.Controllers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Data;
using SharePointMigration.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SharePointMigration.FromD365Functions
{
    public class SubdivisionRequirementsListTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public SubdivisionRequirementsListTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("SubdivisionRequirementsListTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 20 */2 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("subdivisionrequirementslist"), StorageAccount("AzureWebJobsStorage")] ICollector<UnitModel> msg, ILogger log)
        {
            try {
                log.LogInformation($"SubdivisionRequirementsListTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetUnits().Where(x => !string.IsNullOrWhiteSpace(x.WarehouseId)).Take(10);
                Parallel.ForEach(items, item =>
                {
                    log.LogInformation($"SubdivisionRequirementsListTimerFunction Timer trigger function executed at: {DateTime.Now}");
                    var items = _dynamicsApi.GetUnits().Take(10);
                    Parallel.ForEach(items, item =>
                    {
                        msg.Add(item);
                    });
                });
                } catch (Exception ex) { log.LogError(ex.Message, ex); throw; }
        }
    }

        
}
