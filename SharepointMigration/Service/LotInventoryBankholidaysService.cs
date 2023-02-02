using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class LotInventoryBankholidaysService : SiteService<LotInventoryBankholidaysModel> , ILotInventoryBankholidaysService
    {
        public LotInventoryBankholidaysService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:LotInventoryBankholidays:SiteId"];
            _listId = _configuration["SharePointList:LotInventoryBankholidays:ListId"];
            _keyField = LotInventoryBankholidays.HolidayYear;
        }

        protected override Dictionary<string, object> BuildDictionary(LotInventoryBankholidaysModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(LotInventoryBankholidays.HolidayYear, data.HolidayYear);
            dict.Add(LotInventoryBankholidays.HolidayDate, data.HolidayDate);
          
            
            return dict;
        }

        protected override LotInventoryBankholidaysModel ToSiteModel(LotInventoryBankholidaysModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.HolidayYear = data.ContainsKey(LotInventoryBankholidays.HolidayYear) ? data[LotInventoryBankholidays.HolidayYear].ToString() : null;
            siteModel.HolidayDate = data.ContainsKey(LotInventoryBankholidays.HolidayDate) ? (DateTime)data[LotInventoryBankholidays.HolidayDate] : null;
            
            return siteModel;
        }

    }
}