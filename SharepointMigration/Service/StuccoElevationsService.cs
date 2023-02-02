using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class StuccoElevationsService : SiteService<StuccoElevationsModel> , IStuccoElevationsService
    {
        public StuccoElevationsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:StuccoElevations:SiteId"];
            _listId = _configuration["SharePointList:StuccoElevations:ListId"];
            _keyField = StuccoElevations.PHS;
        }

        protected override Dictionary<string, object> BuildDictionary(StuccoElevationsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(StuccoElevations.PHS, data.PHS);
            dict.Add(StuccoElevations.Project, data.Project);
            dict.Add(StuccoElevations.Plan, data.Plan);
            dict.Add(StuccoElevations.Elevation, data.Elevation);
            dict.Add(StuccoElevations.Swing, data.Swing);
            dict.Add(StuccoElevations.Extra, data.Extra);
            dict.Add(StuccoElevations.CostCode, data.CostCode);
            dict.Add(StuccoElevations.CT, data.CT);
            dict.Add(StuccoElevations.ItemNumber, data.ItemNumber);
            dict.Add(StuccoElevations.QTY, data.QTY);
            dict.Add(StuccoElevations.GRP, data.GRP);
            dict.Add(StuccoElevations.TYP, data.TYP);
            dict.Add(StuccoElevations.LongDescription, data.LongDescription);
            dict.Add(StuccoElevations.DFTREFPROJ, data.DFTREFPROJ);
            dict.Add(StuccoElevations.ProjectStatus, data.ProjectStatus);
            dict.Add(StuccoElevations.Estimator, data.Estimator);
            dict.Add(StuccoElevations.PlanGroup, data.PlanGroup);
            dict.Add(StuccoElevations.PlanGroupDescription, data.PlanGroupDescription);
            dict.Add(StuccoElevations.Description, data.Description);
            return dict;
        }

        protected override StuccoElevationsModel ToSiteModel(StuccoElevationsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.PHS = data.ContainsKey(StuccoElevations.PHS) ? data[StuccoElevations.PHS].ToString() : null;
            siteModel.Project = data.ContainsKey(StuccoElevations.Project) ? data[StuccoElevations.Project].ToString() : null;
            siteModel.Plan = data.ContainsKey(StuccoElevations.Plan) ? data[StuccoElevations.Plan].ToString() : null;
            siteModel.Elevation = data.ContainsKey(StuccoElevations.Elevation) ? data[StuccoElevations.Elevation].ToString() : null;
            siteModel.Swing = data.ContainsKey(StuccoElevations.Swing) ? data[StuccoElevations.Swing].ToString() : null;
            siteModel.Extra = data.ContainsKey(StuccoElevations.Extra) ? data[StuccoElevations.Extra].ToString() : null;
            siteModel.CostCode = data.ContainsKey(StuccoElevations.CostCode) ? data[StuccoElevations.CostCode].ToString() : null;
            siteModel.CT = data.ContainsKey(StuccoElevations.CT) ? data[StuccoElevations.CT].ToString() : null;
            siteModel.ItemNumber = data.ContainsKey(StuccoElevations.ItemNumber) ? data[StuccoElevations.ItemNumber].ToString() : null;
            siteModel.QTY = data.ContainsKey(StuccoElevations.QTY) ? data[StuccoElevations.QTY].ToString() : null;
            siteModel.GRP = data.ContainsKey(StuccoElevations.GRP) ? data[StuccoElevations.GRP].ToString() : null;
            siteModel.TYP = data.ContainsKey(StuccoElevations.TYP) ? data[StuccoElevations.TYP].ToString() : null;
            siteModel.LongDescription = data.ContainsKey(StuccoElevations.LongDescription) ? data[StuccoElevations.LongDescription].ToString() : null;
            siteModel.DFTREFPROJ = data.ContainsKey(StuccoElevations.DFTREFPROJ) ? data[StuccoElevations.DFTREFPROJ].ToString() : null;
            siteModel.ProjectStatus = data.ContainsKey(StuccoElevations.ProjectStatus) ? data[StuccoElevations.ProjectStatus].ToString() : null;
            siteModel.Estimator = data.ContainsKey(StuccoElevations.Estimator) ? data[StuccoElevations.Estimator].ToString() : null;
            siteModel.PlanGroup = data.ContainsKey(StuccoElevations.PlanGroup) ? data[StuccoElevations.PlanGroup].ToString() : null;
            siteModel.PlanGroupDescription = data.ContainsKey(StuccoElevations.PlanGroupDescription) ? data[StuccoElevations.PlanGroupDescription].ToString() : null;
            siteModel.Description = data.ContainsKey(StuccoElevations.Description) ? data[StuccoElevations.Description].ToString() : null;
            
            return siteModel;
        }

    }
}