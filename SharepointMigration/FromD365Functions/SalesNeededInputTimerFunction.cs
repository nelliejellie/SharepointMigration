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
    public class SalesNeededInputTimerFunction
    {  
        private readonly DynamicsApi _dynamicsApi;

        public SalesNeededInputTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("SalesNeededInputTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 0 */2 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("salesneededinput"), StorageAccount("AzureWebJobsStorage")] ICollector<ProjectModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"SalesNeededInputTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetProjects().Take(20);


                Parallel.ForEach(items, item =>
                {

                    msg.Add(item);
                });
            }
            catch(Exception ex) { log.LogError(ex.Message, ex);throw; }
        }

       
    }
}