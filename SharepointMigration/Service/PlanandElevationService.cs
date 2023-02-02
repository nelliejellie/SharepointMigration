using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class PlanandElevationService : SiteService<PlanandElevationModel> , IPlanandElevationService
    {
        public PlanandElevationService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:PlanandElevation:SiteId"];
            _listId = _configuration["SharePointList:PlanandElevation:ListId"];
            _keyField = PlanandElevation.PlanKey;
            _keyField2 = PlanandElevation.Elevation;
        }

        protected override Dictionary<string, object> BuildDictionary(PlanandElevationModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(PlanandElevation.Title, data.Title);
            dict.Add(PlanandElevation.Plan, data.Plan);
            dict.Add(PlanandElevation.Elevation, data.Elevation);
            dict.Add(PlanandElevation.PlanStatus, data.PlanStatus);
            dict.Add(PlanandElevation.PlanKey, data.PlanKey);
            
            return dict;
        }

        protected override PlanandElevationModel ToSiteModel(PlanandElevationModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.Title = data.ContainsKey(PlanandElevation.Title) ? data[PlanandElevation.Title].ToString() : null;
            siteModel.Plan = data.ContainsKey(PlanandElevation.Plan) ? data[PlanandElevation.Plan].ToString() : null;
            siteModel.Elevation = data.ContainsKey(PlanandElevation.Elevation) ? data[PlanandElevation.Elevation].ToString() : null;
            siteModel.PlanStatus = data.ContainsKey(PlanandElevation.PlanStatus) ? data[PlanandElevation.PlanStatus].ToString() : null;
            siteModel.PlanKey = data.ContainsKey(PlanandElevation.PlanKey) ? data[PlanandElevation.PlanKey].ToString() : null;
            
            return siteModel;
        }

    }
}