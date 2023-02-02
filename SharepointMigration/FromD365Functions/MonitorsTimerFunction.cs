using Erp.Api.Controllers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using SharePointMigration.Data;
using SharePointMigration.Model;
using SharePointMigration.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SharePointMigration.FromD365Functions
{
    public class MonitorsTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public MonitorsTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("MonitorsTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 20 */2 * * *", 
            #if DEBUG
                 RunOnStartup=false
            #endif    
            )]TimerInfo myTimer, [Queue("monitors"), StorageAccount("AzureWebJobsStorage")] ICollector<UnitModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"MonitorsTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetUnits().Take(200);

                Parallel.ForEach(items, item =>
                {
                    msg.Add(item);
                });
            }
            catch(Exception ex) { log.LogError(ex.Message,ex); throw; }

        }
    }
}