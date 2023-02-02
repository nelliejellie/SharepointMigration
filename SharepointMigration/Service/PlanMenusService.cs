using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class PlanMenusService : SiteService<PlanMenusModel> , IPlanMenusService
    {
        public PlanMenusService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:BPSProjectDifferentialsService:SiteId"];
            _listId = _configuration["SharePointList:BPSProjectDifferentialsService:ListId"];
            _keyField = PlanMenus.PlanMenuId;
        }

        protected override Dictionary<string, object> BuildDictionary(PlanMenusModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(PlanMenus.PlanMenuId, data.PlanMenuId);
            dict.Add(PlanMenus.PlanMenuActive, data.PlanMenuActive);
            dict.Add(PlanMenus.Phase, data.Phase);
            dict.Add(PlanMenus.PlanMenuDescription, data.PlanMenuDescription);
            dict.Add(PlanMenus.EffectiveDate, data.EffectiveDate);
            dict.Add(PlanMenus.LotBaseAmount, data.LotBaseAmount);
            dict.Add(PlanMenus.PropertyMargin, data.PropertyMargin);
            dict.Add(PlanMenus.FooterNotes, data.FooterNotes);
            dict.Add(PlanMenus.PhaseDescription, data.PhaseDescription);
            dict.Add(PlanMenus.PlanMenuLookup, data.PlanMenuLookup);
            return dict;
        }

        protected override PlanMenusModel ToSiteModel(PlanMenusModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.PlanMenuId = data.ContainsKey(PlanMenus.PlanMenuId) ? data[PlanMenus.PlanMenuId].ToString() : null;
            siteModel.PlanMenuActive = data.ContainsKey(PlanMenus.PlanMenuActive) ? data[PlanMenus.PlanMenuActive].ToString() : null;
            siteModel.Phase = data.ContainsKey(PlanMenus.Phase) ? data[PlanMenus.Phase].ToString() : null;
            siteModel.PlanMenuDescription = data.ContainsKey(PlanMenus.PlanMenuDescription) ? data[PlanMenus.PlanMenuDescription].ToString() : null;
            siteModel.EffectiveDate = data.ContainsKey(PlanMenus.EffectiveDate) ? (DateTime)data[PlanMenus.EffectiveDate] : null;
            siteModel.LotBaseAmount = data.ContainsKey(PlanMenus.LotBaseAmount) ? data[PlanMenus.LotBaseAmount].ToString() : null;
            siteModel.PropertyMargin = data.ContainsKey(PlanMenus.PropertyMargin) ? data[PlanMenus.PropertyMargin].ToString() : null;
            siteModel.PropertyMargin = data.ContainsKey(PlanMenus.PropertyMargin) ? data[PlanMenus.PropertyMargin].ToString() : null;
            siteModel.FooterNotes = data.ContainsKey(PlanMenus.FooterNotes) ? data[PlanMenus.FooterNotes].ToString() : null;
            siteModel.PhaseDescription = data.ContainsKey(PlanMenus.PhaseDescription) ? data[PlanMenus.PhaseDescription].ToString() : null;
            siteModel.PlanMenuLookup = data.ContainsKey(PlanMenus.PlanMenuLookup) ? data[PlanMenus.PlanMenuLookup].ToString() : null;
            return siteModel;
        }

    }
}