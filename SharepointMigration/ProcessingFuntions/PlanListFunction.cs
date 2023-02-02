using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Model;
using SharePointMigration.Service;

namespace SharePointMigration.ProcessingFuntions
{
    public class PlanListFunction
    {
        private readonly IPlanListService _siteService;

        public PlanListFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<IPlanListService>();
        }

        [FunctionName("PlanListFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("planlist", Connection = "AzureWebJobsStorage")] PlanListModel myQueueItem, ILogger log)
        {try{
            log.LogInformation($"PlanListFunction Queue trigger function processed: {myQueueItem.PlanID}");
            var siteRecord = await _siteService.Get(myQueueItem.PlanID);
            if (siteRecord.Id == null)
            {
                _siteService.Create(myQueueItem.PlanID, myQueueItem);
            }
            else
            {
                
                siteRecord = await _siteService.Update(myQueueItem.PlanID, myQueueItem);
            }
        }
            catch (Exception ex) { log.LogError(ex.Message, ex); throw; }
        }
    }
}