using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class EstimatorDetailsService : SiteService<EstimatorDetailsModel> , IEstimatorDetailsService
    {
        public EstimatorDetailsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:EstimatorDetails:SiteId"];
            _listId = _configuration["SharePointList:EstimatorDetails:ListId"];
            _keyField = EstimatorDetails.EstimatorName;
        }

        protected override Dictionary<string, object> BuildDictionary(EstimatorDetailsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(EstimatorDetails.EstimatorName, data.EstimatorName);
            dict.Add(EstimatorDetails.EstimatorEmailAddress, data.EstimatorEmailAddress);
            
            return dict;
        }

        protected override EstimatorDetailsModel ToSiteModel(EstimatorDetailsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.EstimatorName = data.ContainsKey(EstimatorDetails.EstimatorName) ? data[EstimatorDetails.EstimatorName].ToString() : null;
            siteModel.EstimatorEmailAddress = data.ContainsKey(EstimatorDetails.EstimatorEmailAddress) ? data[EstimatorDetails.EstimatorEmailAddress].ToString() : null;
            
            return siteModel;
        }

    }
}