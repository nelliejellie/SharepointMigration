using Erp.Api.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.OData.Client;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SharePointMigration.Data
{
    public class DynamicsApi
    {
        private readonly string ErpApiUrl;

        private readonly ErpContainer _erpContainer;
        private readonly IConfiguration _configuration;

        public DynamicsApi(IServiceProvider serviceProvider)
        {
            _configuration = serviceProvider.GetService<IConfiguration>();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            _erpContainer = new ErpContainer(new Uri($"{_configuration["ErpApiUrl"]}/odata"));
            _erpContainer.Configurations.RequestPipeline.OnMessageCreating += 
                delegate (DataServiceClientRequestMessageArgs messageArgs)
                {
                    var req = new HttpClientRequestMessage(messageArgs);
                    req.SetHeader("Authorization", "Bearer " +  GetToken());
                    return req;
                };
        }        
        private string GetToken()
        {
            var tenantId = _configuration["ErpApiTenentId"];
            var clientId = _configuration["ErpApiClientId"];
            var secret = _configuration["ErpApiSecret"];
            var scope = _configuration["ErpApiScope"];
            var scopes = new List<string> { scope };

            var app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(secret)
                .Build();

            var result = app.AcquireTokenForClient(scopes).ExecuteAsync().Result;
            return result.AccessToken;
        }

        public List<ProjectModel> GetProjects()
        {
            return _erpContainer.Projects
                .Where(x => x.IsActive)
                .ToList();
        }

        public ProjectModel GetProjects(string id)
        {
            return _erpContainer.Projects
                .Where(x => x.IsActive && x.WarehouseId == id)
                .SingleOrDefault();
        }

        public List<UnitModel> GetUnits()
        {
            try
            {

                var units = _erpContainer.Units.ToList();
                return units;
            }
            catch(Exception ex) { throw ex; }
            //.Where(x => x.ReleaseDate > DateTime.Now.AddDays(-2))
            //.ToList();
        }

        public DivisionModel GetDivision(Guid id)
        {
            //return _erpContainer.Divisions.Where(x => x.DivisionId == id).First();
            var divisions = _erpContainer.Divisions.ToList();
            return divisions.FirstOrDefault(x => x.DivisionId == id);
        }

        public List<PlanMenuModel> GetPlanList()
        {
            return _erpContainer.PlanMenu.ToList();
        }

        //public List<MonitorsModel> GetMonitors()
        //{
        //    return _erpContainer.p
        //}
        public StageOfConstructionModel GetStageForMonitor(int id)
        {
            return _erpContainer.StageOfConstructions.Where(x => x.Id == id).SingleOrDefault();
        }
        public List<PlanElevationModel> GetPlanElevation(string planId)
        {
            return _erpContainer.PlanElevation.Where(x=> x.Plan == planId).ToList();
        }

        public List<PlanElevationModel> GetPlanElevations()
        {
            return _erpContainer.PlanElevation.Where(x => x.ProductState == "Active").ToList();
        }

    }
}
