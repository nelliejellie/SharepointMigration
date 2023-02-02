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
    public class DesignCenterProjectEmailListTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public DesignCenterProjectEmailListTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("DesignCenterProjectEmailListTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 0 3 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("designcenterprojectemaillist"), StorageAccount("AzureWebJobsStorage")] ICollector<DesignCenterProjectEmailListModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"DesignCenterProjectEmailListTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetUnits().Take(10);
                foreach (var item in items)
                {
                    //msg.Add(Map(item));
                }
            }
            catch(Exception ex) { log.LogError(ex.Message,ex); throw; }
        }

        private DesignCenterProjectEmailListModel Map(UnitModel item)
        {
            var result = new DesignCenterProjectEmailListModel();
            return result;
        }
    }
}