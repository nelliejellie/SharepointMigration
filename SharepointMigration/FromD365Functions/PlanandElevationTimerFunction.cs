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
    public class PlanandElevationTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public PlanandElevationTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("PlanandElevationTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 10 */2 * * *", 
            #if DEBUG
                 RunOnStartup= true
            #endif    
            )]TimerInfo myTimer, [Queue("planandelevation"), StorageAccount("AzureWebJobsStorage")] ICollector<PlanandElevationModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"PlanandElevationTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetPlanList().ToList().Take(100);
                List<PlanandElevationModel> UnfilteredList = new List<PlanandElevationModel>();
                
                foreach (var item in items)
                {
                    var mapped = Map(item);
                    if (mapped.Count > 0)
                    {
                        foreach (var item2 in mapped)
                        {
                            UnfilteredList.Add(item2);
                        }
                    }
                }
             var Filteredlist =  UnfilteredList.GroupBy(o => new { o.PlanKey,o.Elevation,o.Plan}).Select(o => o.FirstOrDefault()).ToList();
                Parallel.ForEach(Filteredlist, item =>
                {
                    msg.Add(item);
                });
            }
            catch(Exception ex) { log.LogError(ex.Message, ex);throw; }
        }

        private List<PlanandElevationModel> Map(PlanMenuModel item)
        {
            try
            {
                var results = new List<PlanandElevationModel>();
                var elevations = _dynamicsApi.GetPlanElevation(item.ProductNumber);
                foreach (var elevation in elevations)
                {
                    var result = new PlanandElevationModel();
                    result.PlanKey = $"{item.ProductNumber}-{elevation.Elevation}";
                    result.Plan = item.ProductNumber;
                    result.Elevation = elevation.Elevation;
                    result.PlanStatus = elevation.ProductState;
                    results.Add(result);
                }
                return results;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}