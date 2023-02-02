using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class LotInventoryDeveloperListService : SiteService<LotInventoryDeveloperListModel> , ILotInventoryDeveloperListService
    {
        public LotInventoryDeveloperListService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:BPSProjectDifferentialsService:SiteId"];
            _listId = _configuration["SharePointList:BPSProjectDifferentialsService:ListId"];
            _keyField = LotInventoryDeveloperList.ProjectNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(LotInventoryDeveloperListModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(LotInventoryDeveloperList.ProjectNumber, data.ProjectNumber);
            dict.Add(LotInventoryDeveloperList.ContactName, data.ContactName);
            dict.Add(LotInventoryDeveloperList.FaxNumber, data.FaxNumber);
            dict.Add(LotInventoryDeveloperList.EmailAddress, data.EmailAddress);
            
            return dict;
        }

        protected override LotInventoryDeveloperListModel ToSiteModel(LotInventoryDeveloperListModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectNumber = data.ContainsKey(LotInventoryDeveloperList.ProjectNumber) ? data[LotInventoryDeveloperList.ProjectNumber].ToString() : null;
            siteModel.ContactName = data.ContainsKey(LotInventoryDeveloperList.ContactName) ? data[LotInventoryDeveloperList.ContactName].ToString() : null;
            siteModel.FaxNumber = data.ContainsKey(LotInventoryDeveloperList.FaxNumber) ? data[LotInventoryDeveloperList.FaxNumber].ToString() : null;
            siteModel.EmailAddress = data.ContainsKey(LotInventoryDeveloperList.EmailAddress) ? data[LotInventoryDeveloperList.EmailAddress].ToString() : null;
            
            return siteModel;
        }

    }
}