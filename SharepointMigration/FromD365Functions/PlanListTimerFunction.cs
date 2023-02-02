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
    public class PlanListTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public PlanListTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("PlanListTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 15 */2 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("planlist"), StorageAccount("AzureWebJobsStorage")] ICollector<PlanListModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"PlanListTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetPlanList();
                foreach (var item in items)
                {
                    var mapped = Map(item);
                    if (!String.IsNullOrEmpty(mapped.Releases)) msg.Add(mapped);
                }
            }catch(Exception ex) { log.LogError(ex.Message, ex);throw; }
        }

        private PlanListModel Map(PlanMenuModel item)
        {
            var result = new PlanListModel();
            var elevations = _dynamicsApi.GetPlanElevation(item.ProductNumber);
            var elevation = elevations.FirstOrDefault();
            if (elevation != null)
            {
                result.PlanSqFt = elevation.SqFt;
                result.Stories = elevation.NumFloor;
                result.PlanStatus = elevation.ProductState;
                result.Releases = elevations.Count.ToString();
            }
            result.PlanID = item.ProductNumber;
            result.PlanMenu = item.ProductCategoryName;
            return result;
        }
    }
}