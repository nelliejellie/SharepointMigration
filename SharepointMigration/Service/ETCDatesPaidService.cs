using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class ETCDatesPaidService : SiteService<ETCDatesPaidModel> , IETCDatesPaidService
    {
        public ETCDatesPaidService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:BPSProjectDifferentialsService:SiteId"];
            _listId = _configuration["SharePointList:BPSProjectDifferentialsService:ListId"];
            _keyField = ETCDatesPaid.ClosingDate;
        }

        protected override Dictionary<string, object> BuildDictionary(ETCDatesPaidModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(ETCDatesPaid.ClosingDate, data.ClosingDate);
            dict.Add(ETCDatesPaid.PaidDate, data.PaidDate);
            dict.Add(ETCDatesPaid.CheckNumber, data.CheckNumber);
            
            return dict;
        }

        protected override ETCDatesPaidModel ToSiteModel(ETCDatesPaidModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ClosingDate = data.ContainsKey(ETCDatesPaid.ClosingDate) ? data[ETCDatesPaid.ClosingDate].ToString() : null;
            siteModel.PaidDate = data.ContainsKey(ETCDatesPaid.PaidDate) ? data[ETCDatesPaid.PaidDate].ToString() : null;
            siteModel.CheckNumber = data.ContainsKey(ETCDatesPaid.CheckNumber) ? data[ETCDatesPaid.CheckNumber].ToString() : null;
            
            return siteModel;
        }

    }
}