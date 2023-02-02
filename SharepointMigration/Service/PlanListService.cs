using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class PlanListService : SiteService<PlanListModel> , IPlanListService
    {
        public PlanListService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:PlanList:SiteId"];
            _listId = _configuration["SharePointList:PlanList:ListId"];
            _keyField = PlanList.PlanID;
        }

        protected override Dictionary<string, object> BuildDictionary(PlanListModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(PlanList.PlanID, data.PlanID);
            dict.Add(PlanList.PlanMenu, data.PlanMenu);
            dict.Add(PlanList.PlanStatus, data.PlanStatus);
            dict.Add(PlanList.Releases, data.Releases);
            dict.Add(PlanList.PlanSqFt, data.PlanSqFt);
            dict.Add(PlanList.Stories, data.Stories);
            return dict;
        }

        protected override PlanListModel ToSiteModel(PlanListModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.PlanID = data.ContainsKey(PlanList.PlanID) ? data[PlanList.PlanID].ToString() : null;
            siteModel.PlanMenu = data.ContainsKey(PlanList.PlanMenu) ? data[PlanList.PlanMenu].ToString() : null;
            siteModel.PlanStatus = data.ContainsKey(PlanList.PlanStatus) ? data[PlanList.PlanStatus].ToString() : null;
            siteModel.Releases = data.ContainsKey(PlanList.Releases) ? data[PlanList.Releases].ToString() : null;
            siteModel.PlanSqFt = data.ContainsKey(PlanList.PlanSqFt) ? data[PlanList.PlanSqFt].ToString() : null;
            siteModel.Stories = data.ContainsKey(PlanList.Stories) ? data[PlanList.Stories].ToString() : null;
            return siteModel;
        }

    }
}