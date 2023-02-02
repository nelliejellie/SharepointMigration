using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Model;
using SharePointMigration.Service;
using System;
using System.Threading.Tasks;

namespace SharePointMigration.ProcessingFuntions
{
    public class ProjectsFunction
    {
        private readonly IProjectsService _siteService;

        public ProjectsFunction(IServiceProvider serviceProvider)
        {
            _siteService = serviceProvider.GetService<IProjectsService>();
        }

        [FunctionName("ProjectsFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([QueueTrigger("projects", Connection = "AzureWebJobsStorage")] ProjectsModel myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"ProjectsFunction Queue trigger function processed: {myQueueItem}");
                var siteRecord = await _siteService.Get(myQueueItem.Number);
                if (siteRecord.Id == null)
                {
                    _siteService.Create(myQueueItem.Number, myQueueItem);
                }
                else
                {
                    myQueueItem.Id = siteRecord.Id;
                    siteRecord = await _siteService.Update(myQueueItem.Number, myQueueItem);
                }
            }catch(Exception ex) { log.LogError(ex.Message,ex); throw; }
        }
    }
}
