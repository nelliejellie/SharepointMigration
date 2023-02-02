using Erp.Api.Controllers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharePointMigration.Data;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharePointMigration.FromD365Functions
{
    public class ElevationsListTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public ElevationsListTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("ElevationsListTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 5 */2 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("elevationslist"), StorageAccount("AzureWebJobsStorage")] ICollector<ElevationsListModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"ElevationsListTimerFunction Timer trigger function executed at: {DateTime.Now}");

                var items = _dynamicsApi.GetPlanList();
                foreach (var item in items)
                {
                    var mapped = Map(item);
                    if (mapped.Count > 0)
                    {
                        foreach (var item2 in mapped) msg.Add(item2);
                    }
                }
            }
            catch (Exception ex) { log.LogError(ex.Message,ex); throw; }   
        }


        private List<ElevationsListModel> Map(PlanMenuModel item)
        {
            var results = new List<ElevationsListModel>();
            var elevations = _dynamicsApi.GetPlanElevation(item.ProductNumber);
            foreach (var elevation in elevations)
            {
                var result = new ElevationsListModel();
                result.PlanId = item.ProductNumber;
                result.PlanMenu = item.ProductCategoryName;
                result.Elevation = elevation.Elevation;
                result.PlanSqFt = elevation.SqFt;
                result.Stories = elevation.NumFloor;
                result.Releases = elevations.Count.ToString();
                result.PlanStatus = elevation.ProductState;
                result.ElevationStatus = elevation.ProductState;
                results.Add(result);
            }
            return results;
        }

        private string RemoveUnwantedDecimalAndFormatNumbersCorrectly(string number)
        {
            var value = Convert.ToDecimal(number);
            return value.ToString("#,##0");
        }
    }
}