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
    public class ProjectsTimerFunction
    {
        private readonly DynamicsApi _dynamicsApi;

        public ProjectsTimerFunction(IServiceProvider serviceProvider)
        {
            _dynamicsApi = serviceProvider.GetService<DynamicsApi>();
        }

        [FunctionName("ProjectsTimerFunction")]
        [FixedDelayRetry(2, "00:00:10")]
        public async Task RunAsync([TimerTrigger("0 0 */2 * * *", 
            #if DEBUG
                 RunOnStartup= false
            #endif    
            )]TimerInfo myTimer, [Queue("projects"), StorageAccount("AzureWebJobsStorage")] ICollector<ProjectsModel> msg, ILogger log)
        {
            try
            {
                log.LogInformation($"ProjectsTimerFunction Timer trigger function executed at: {DateTime.Now}");
                var items = _dynamicsApi.GetProjects();
                foreach (var item in items)
                {
                    var msgItem = Map(item);
                    if (!String.IsNullOrEmpty(msgItem.Title))
                    {
                        msg.Add(msgItem);
                    }
                }
            }catch(Exception ex) { log.LogError(ex.Message, ex);throw; }
        }

        private ProjectsModel Map(ProjectModel item)
        {
            var division = _dynamicsApi.GetDivision(item.DivisionId);
            var result = new ProjectsModel();
            if (division != null)
            {
                //result.Id = Guid.NewGuid().ToString();
                result.Brand = ConcatenateHomes(division.BusinessUnit);
                result.Market = ReturnFullCityName(division.MarketCode);
                result.Number = item.Number.ToString();
                result.Title = CapitalizeFirtsLetter(item.Name);
            }
            if (item.Number == 0) result.Title = "";
            return result;
        }

        private string CapitalizeFirtsLetter(string words)
        {
            var splitWords = words.Split(' ');
            var newWord = "";
            foreach (var word in splitWords)
            {
                var currentWord = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
                newWord += currentWord + " ";
            }
            return newWord;
        }

        private string ConcatenateHomes(string title)
        {
            return CapitalizeFirtsLetter(title) + " Homes";
        }

        private string ReturnFullCityName(string key)
        {
            var ListOfCities = new Dictionary<string, string>()
        {
            {"AU","Austin"},
            {"DFW","Dallas"},
            {"HOU","Houston"},
            {"SA", "San Antonio"}
        };
            if (ListOfCities.ContainsKey(key))
                return ListOfCities[key];
            return key;
        }
    }
}