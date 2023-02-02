using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class StuccoColorsService : SiteService<StuccoColorsModel> , IStuccoColorsService
    {
        public StuccoColorsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:BPSProjectDifferentialsService:SiteId"];
            _listId = _configuration["SharePointList:BPSProjectDifferentialsService:ListId"];
            _keyField = StuccoColors.StuccoName;
        }

        protected override Dictionary<string, object> BuildDictionary(StuccoColorsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(StuccoColors.StuccoName, data.StuccoName);
            dict.Add(StuccoColors.StuccoColor, data.StuccoColor);
            
            return dict;
        }

        protected override StuccoColorsModel ToSiteModel(StuccoColorsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.StuccoName = data.ContainsKey(StuccoColors.StuccoName) ? data[StuccoColors.StuccoName].ToString() : null;
            siteModel.StuccoColor = data.ContainsKey(StuccoColors.StuccoColor) ? data[StuccoColors.StuccoColor].ToString() : null;
            
            return siteModel;
        }

    }
}