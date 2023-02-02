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
    public class JobDataForLotFitRequestsTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public JobDataForLotFitRequestsTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("JobDataForLotFitRequestsTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 25 */2 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("jobdataforlotfitrequests"), StorageAccount("AzureWebJobsStorage")] ICollector<UnitModel> msg, ILogger log)
        {
            log.LogInformation($"JobDataForLotFitRequestsTimerFunction Timer trigger function executed at: {DateTime.Now}");
            try
            {
                var items = _dynamicsApi.GetUnits().Take(10);
                Parallel.ForEach(items, item =>
                {
                    msg.Add(item);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("paused");
                Console.WriteLine(ex.Message);
                log.LogError(ex.Message, ex);
                throw;
            }
            
        }

       
    }
}