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
    public class DigitalPlatMapsTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public DigitalPlatMapsTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("DigitalPlatMapsTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 0 3 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("digitalplatmaps"), StorageAccount("AzureWebJobsStorage")] ICollector<ProjectsModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"DigitalPlatMapsTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetProjects();
                foreach (var item in items)
                {
                    //msg.Add(msgItem);
                }
            }catch(Exception ex) { log.LogError(ex.Message,ex); }   
        }

        private ProjectsModel Map(ProjectModel item)
        {
            var division = _dynamicsApi.GetDivision(item.DivisionId);
            var result = new ProjectsModel();
            if (division != null)
            {
                result.Brand = division.BusinessUnit;
                result.Market = division.MarketCode;
                result.Number = item.Number.ToString();
                result.Title = item.Name;
            }
            return result;
        }
    }
}