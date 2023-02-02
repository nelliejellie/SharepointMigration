using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class PlanOptionsSqFtChangeService : SiteService<PlanOptionSqFtChangeModel> , IPlanOptionsSqFtChangeService
    {
        public PlanOptionsSqFtChangeService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:PlanOptionSqFtChange:SiteId"];
            _listId = _configuration["SharePointList:PlanOptionSqFtChange:ListId"];
            _keyField = PlanOptionsSqFtChange.Plan;
        }

        protected override Dictionary<string, object> BuildDictionary(PlanOptionSqFtChangeModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(PlanOptionsSqFtChange.Plan, data.Plan);
            dict.Add(PlanOptionsSqFtChange.PlanElevation, data.PlanElevation);
            dict.Add(PlanOptionsSqFtChange.CombinationGroup, data.CombinationGroup);
            dict.Add(PlanOptionsSqFtChange.OptionCode, data.OptionCode);
            dict.Add(PlanOptionsSqFtChange.IsActive, data.IsActive);
            dict.Add(PlanOptionsSqFtChange.SquareFootageChange, data.SquareFootageChange);
            dict.Add(PlanOptionsSqFtChange.Garage, data.Garage);
            dict.Add(PlanOptionsSqFtChange.Stories, data.Stories);
            dict.Add(PlanOptionsSqFtChange.Bedrooms, data.Bedrooms);
            dict.Add(PlanOptionsSqFtChange.Bathroom, data.Bathroom);
            dict.Add(PlanOptionsSqFtChange.HalfBath, data.HalfBath);
            dict.Add(PlanOptionsSqFtChange.Library, data.Library);
            dict.Add(PlanOptionsSqFtChange.Media, data.Media);
            dict.Add(PlanOptionsSqFtChange.GameRoom, data.GameRoom);
            dict.Add(PlanOptionsSqFtChange.DuplicateSqFtPlanMenu, data.DuplicateSqFtPlanMenu);
            dict.Add(PlanOptionsSqFtChange.IncludeSqFtPlanMenu, data.IncludeSqFtPlanMenu);
            return dict;
        }

        protected override PlanOptionSqFtChangeModel ToSiteModel(PlanOptionSqFtChangeModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.Plan = data.ContainsKey(PlanOptionsSqFtChange.Plan) ? data[PlanOptionsSqFtChange.Plan].ToString() : null;
            siteModel.PlanElevation = data.ContainsKey(PlanOptionsSqFtChange.PlanElevation) ? data[PlanOptionsSqFtChange.PlanElevation].ToString() : null;
            siteModel.CombinationGroup = data.ContainsKey(PlanOptionsSqFtChange.CombinationGroup) ? data[PlanOptionsSqFtChange.CombinationGroup].ToString() : null;
            siteModel.OptionCode = data.ContainsKey(PlanOptionsSqFtChange.OptionCode) ? data[PlanOptionsSqFtChange.OptionCode].ToString() : null;
            siteModel.IsActive = data.ContainsKey(PlanOptionsSqFtChange.IsActive) ? data[PlanOptionsSqFtChange.IsActive].ToString() : null;
            siteModel.SquareFootageChange = data.ContainsKey(PlanOptionsSqFtChange.SquareFootageChange) ? data[PlanOptionsSqFtChange.SquareFootageChange].ToString() : null;
            siteModel.Garage = data.ContainsKey(PlanOptionsSqFtChange.Garage) ? data[PlanOptionsSqFtChange.Garage].ToString() : null;
            siteModel.Stories = data.ContainsKey(PlanOptionsSqFtChange.Stories) ? data[PlanOptionsSqFtChange.Stories].ToString() : null;
            siteModel.Bedrooms = data.ContainsKey(PlanOptionsSqFtChange.Bedrooms) ? data[PlanOptionsSqFtChange.Bedrooms].ToString() : null;
            siteModel.Bathroom = data.ContainsKey(PlanOptionsSqFtChange.Bathroom) ? data[PlanOptionsSqFtChange.Bathroom].ToString() : null;
            siteModel.HalfBath = data.ContainsKey(PlanOptionsSqFtChange.HalfBath) ? data[PlanOptionsSqFtChange.HalfBath].ToString() : null;
            siteModel.Library = data.ContainsKey(PlanOptionsSqFtChange.Library) ? data[PlanOptionsSqFtChange.Library].ToString() : null;
            siteModel.Media = data.ContainsKey(PlanOptionsSqFtChange.Media) ? data[PlanOptionsSqFtChange.Media].ToString() : null;
            siteModel.GameRoom = data.ContainsKey(PlanOptionsSqFtChange.GameRoom) ? data[PlanOptionsSqFtChange.GameRoom].ToString() : null;
            siteModel.DuplicateSqFtPlanMenu = data.ContainsKey(PlanOptionsSqFtChange.DuplicateSqFtPlanMenu) ? data[PlanOptionsSqFtChange.DuplicateSqFtPlanMenu].ToString() : null;
            siteModel.IncludeSqFtPlanMenu = data.ContainsKey(PlanOptionsSqFtChange.IncludeSqFtPlanMenu) ? data[PlanOptionsSqFtChange.IncludeSqFtPlanMenu].ToString() : null;
            return siteModel;
        }

    }
}