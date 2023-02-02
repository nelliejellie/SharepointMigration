using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Model;
using SharePointMigration.Service;
using System;
using System.Threading.Tasks;

namespace SharePointMigration.ProcessingFuntions
{
    public class ElevationsListFunction
    {
        private readonly IElevationsListService _siteService;

        public ElevationsListFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<IElevationsListService>();
        }

        [FunctionName("ElevationsListFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("elevationslist", Connection = "AzureWebJobsStorage")] ElevationsListModel myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"ElevationsListFunction Queue trigger function processed: {myQueueItem}");
                var siteRecord = await _siteService.Get(myQueueItem.PlanId);
                if (siteRecord.Id == null)
                {
                    _siteService.Create(myQueueItem.PlanId, myQueueItem);
                }
                else
                {
                    myQueueItem.Id = siteRecord.Id;
                    siteRecord = await _siteService.Update(myQueueItem.PlanId, myQueueItem);
                }
            }catch (Exception ex) { log.LogError(ex.Message,ex); throw; }
        }
    }
}
