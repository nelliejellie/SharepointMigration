using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class PaintedBrickColorsService : SiteService<PaintedBrickColorsModel> , IPaintedBrickColorsService
    {
        public PaintedBrickColorsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:PaintedBrickColors:SiteId"];
            _listId = _configuration["SharePointList:PaintedBrickColors:ListId"];
            _keyField = PaintedBrickColors.PaintedBrickName;
        }

        protected override Dictionary<string, object> BuildDictionary(PaintedBrickColorsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(PaintedBrickColors.PaintedBrickName, data.PaintedBrickName);
            dict.Add(PaintedBrickColors.PaintedBrickColor, data.PaintedBrickColor);
            
            return dict;
        }

        protected override PaintedBrickColorsModel ToSiteModel(PaintedBrickColorsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.PaintedBrickName = data.ContainsKey(PaintedBrickColors.PaintedBrickName) ? data[PaintedBrickColors.PaintedBrickName].ToString() : null;
            siteModel.PaintedBrickColor = data.ContainsKey(PaintedBrickColors.PaintedBrickColor) ? data[PaintedBrickColors.PaintedBrickColor].ToString() : null;
            
            return siteModel;
        }

    }
}