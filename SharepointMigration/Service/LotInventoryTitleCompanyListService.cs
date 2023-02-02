using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class LotInvenotryTitleCompanyListService : SiteService<LotInventoryTitleCompanyListModel> , ILotInventoryTitleCompanyListService
    {
        public LotInvenotryTitleCompanyListService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:LotInventoryTitleCompanyList:SiteId"];
            _listId = _configuration["SharePointList:LotInventoryTitleCompanyList:ListId"];
            _keyField = LotInventoryTitleCompanyList.ProjectNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(LotInventoryTitleCompanyListModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(LotInventoryTitleCompanyList.ProjectNumber, data.ProjectNumber);
            dict.Add(LotInventoryTitleCompanyList.RegionName, data.RegionName);
            dict.Add(LotInventoryTitleCompanyList.ContactName, data.ContactName);
            dict.Add(LotInventoryTitleCompanyList.FaxNumber, data.FaxNumber);
            dict.Add(LotInventoryTitleCompanyList.EmailAddress, data.EmailAddress);
            
            return dict;
        }

        protected override LotInventoryTitleCompanyListModel ToSiteModel(LotInventoryTitleCompanyListModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectNumber = data.ContainsKey(LotInventoryTitleCompanyList.ProjectNumber) ? data[LotInventoryTitleCompanyList.ProjectNumber].ToString() : null;
            siteModel.RegionName = data.ContainsKey(LotInventoryTitleCompanyList.RegionName) ? data[LotInventoryTitleCompanyList.RegionName].ToString() : null;
            siteModel.ContactName = data.ContainsKey(LotInventoryTitleCompanyList.ContactName) ? data[LotInventoryTitleCompanyList.ContactName].ToString() : null;
            siteModel.FaxNumber = data.ContainsKey(LotInventoryTitleCompanyList.FaxNumber) ? data[LotInventoryTitleCompanyList.FaxNumber].ToString() : null;
            siteModel.EmailAddress = data.ContainsKey(LotInventoryTitleCompanyList.EmailAddress) ? data[LotInventoryTitleCompanyList.EmailAddress].ToString() : null;
            
            return siteModel;
        }

    }
}