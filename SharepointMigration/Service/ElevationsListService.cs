using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class ElevationsListService : SiteService<ElevationsListModel> , IElevationsListService
    {
        public ElevationsListService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:ElevationsList:SiteId"];
            _listId = _configuration["SharePointList:ElevationsList:ListId"];
            _keyField = ElevationsList.PlanId;
            _keyField2 = ElevationsList.Elevation;
        }

        protected override Dictionary<string, object> BuildDictionary(ElevationsListModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(ElevationsList.PlanId, data.PlanId);
            dict.Add(ElevationsList.Elevation, data.Elevation);
            dict.Add(ElevationsList.PlanMenu, data.PlanMenu);
            dict.Add(ElevationsList.PlanStatus, data.PlanStatus);
            dict.Add(ElevationsList.ElevationStatus, data.ElevationStatus);
            dict.Add(ElevationsList.PlanSqFt, data.PlanSqFt);
            dict.Add(ElevationsList.Stories, data.Stories);
            dict.Add(ElevationsList.Releases, data.Releases);
            return dict;
        }

        protected override ElevationsListModel ToSiteModel(ElevationsListModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.PlanId = data.ContainsKey(ElevationsList.PlanId) ? data[ElevationsList.PlanId].ToString() : null;
            siteModel.Elevation = data.ContainsKey(ElevationsList.Elevation) ? data[ElevationsList.Elevation].ToString() : null;
            siteModel.PlanMenu = data.ContainsKey(ElevationsList.PlanMenu) ? data[ElevationsList.PlanMenu].ToString() : null;
            siteModel.PlanStatus = data.ContainsKey(ElevationsList.PlanStatus) ? data[ElevationsList.PlanStatus].ToString() : null;
            siteModel.ElevationStatus = data.ContainsKey(ElevationsList.ElevationStatus) ? data[ElevationsList.ElevationStatus].ToString() : null;
            siteModel.PlanSqFt = data.ContainsKey(ElevationsList.PlanSqFt) ? data[ElevationsList.PlanSqFt].ToString() : null;
            siteModel.Stories = data.ContainsKey(ElevationsList.Stories) ? data[ElevationsList.Stories].ToString() : null;
            siteModel.Releases = data.ContainsKey(ElevationsList.Releases) ? data[ElevationsList.Releases].ToString() : null;
            return siteModel;
        }

    }
}