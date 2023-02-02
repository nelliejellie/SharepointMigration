using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Api.Controllers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Data;
using SharePointMigration.Model;

namespace SharePointMigration.FromD365Functions
{
    public class SubdivisionSelectionTypeTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public SubdivisionSelectionTypeTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("SubdivisionSelectionTypeTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 20 */2 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("subdivisionselectiontypetimerfunction"), StorageAccount("AzureWebJobsStorage")] ICollector<UnitModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"SubdivisionSelectionTypeTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetUnits().Take(10);

                Parallel.ForEach(items, item =>
                {
                    msg.Add(item);
                });
            }catch(Exception ex) { log.LogError(ex.Message, ex);throw; }
        }

    }
}
