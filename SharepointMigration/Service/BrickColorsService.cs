using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class BrickColorsService : SiteService<BrickColorsModel> , IBrickColorsService
    {
        public BrickColorsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:BrickColors:SiteId"];
            _listId = _configuration["SharePointList:BrickColors:ListId"];
            _keyField = BrickColors.BrickSelection;
        }

        protected override Dictionary<string, object> BuildDictionary(BrickColorsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(BrickColors.BrickSelection, data.BrickSelection);
            dict.Add(BrickColors.BrickColorGroup, data.BrickColorGroup);
            dict.Add(BrickColors.BrickColorGroupDallas, data.BrickColorGroupDallas);
            
            return dict;
        }

        protected override BrickColorsModel ToSiteModel(BrickColorsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.BrickSelection = data.ContainsKey(BrickColors.BrickSelection) ? data[BrickColors.BrickSelection].ToString() : null;
            siteModel.BrickColorGroup = data.ContainsKey(BrickColors.BrickColorGroup) ? data[BrickColors.BrickColorGroup].ToString() : null;
            siteModel.BrickColorGroupDallas = data.ContainsKey(BrickColors.BrickColorGroupDallas) ? data[BrickColors.BrickColorGroupDallas].ToString() : null;
            
            return siteModel;
        }

    }
}