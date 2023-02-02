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
    public class PlanandElevationFunction
    {
        private readonly IPlanandElevationService _siteService;

        public PlanandElevationFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<IPlanandElevationService>();
        }

        [FunctionName("PlanandElevationFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("planandelevation", Connection = "AzureWebJobsStorage")] PlanandElevationModel myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"PlanandElevationFunction Queue trigger function processed: {myQueueItem}");
                var siteRecord = await _siteService.Get(myQueueItem.PlanKey, myQueueItem.Elevation);
                if (siteRecord?.Id == null)
                {
                    _siteService.Create(myQueueItem.PlanKey, myQueueItem);
                }
                else
                {
                    myQueueItem.Id = siteRecord.Id;
                    siteRecord = await _siteService.Update(myQueueItem.PlanKey, myQueueItem);
                }
            }catch(Exception ex) { log.LogError(ex.Message, ex);throw; }
        }
    }
}
