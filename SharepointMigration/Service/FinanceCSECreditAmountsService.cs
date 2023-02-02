using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class FinanceCSECreditAmountsService : SiteService<FinanceCSECreditAmountsModel> , IFinanceCSECreditAmountsService
    {
        public FinanceCSECreditAmountsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:FinanceCSECreditAmounts:SiteId"];
            _listId = _configuration["SharePointList:FinanceCSECreditAmounts:ListId"];
            _keyField = FinanceCSECreditAmounts.ProjectNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(FinanceCSECreditAmountsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(FinanceCSECreditAmounts.ProjectYear, data.ProjectYear);
            dict.Add(FinanceCSECreditAmounts.ProjectNumber, data.ProjectNumber);
            dict.Add(FinanceCSECreditAmounts.January, data.January);
            dict.Add(FinanceCSECreditAmounts.February, data.February);
            dict.Add(FinanceCSECreditAmounts.March, data.March);
            dict.Add(FinanceCSECreditAmounts.April, data.April);
            dict.Add(FinanceCSECreditAmounts.May, data.May);
            dict.Add(FinanceCSECreditAmounts.June, data.June);
            dict.Add(FinanceCSECreditAmounts.July, data.July);
            dict.Add(FinanceCSECreditAmounts.August, data.August);
            dict.Add(FinanceCSECreditAmounts.September, data.September);
            dict.Add(FinanceCSECreditAmounts.October, data.October);
            dict.Add(FinanceCSECreditAmounts.November, data.November);
            dict.Add(FinanceCSECreditAmounts.December, data.December);
            
            return dict;
        }

        protected override FinanceCSECreditAmountsModel ToSiteModel(FinanceCSECreditAmountsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectYear = data.ContainsKey(FinanceCSECreditAmounts.ProjectYear) ? data[FinanceCSECreditAmounts.ProjectYear].ToString() : null;
            siteModel.ProjectNumber = data.ContainsKey(FinanceCSECreditAmounts.ProjectNumber) ? data[FinanceCSECreditAmounts.ProjectNumber].ToString() : null;
            siteModel.January = data.ContainsKey(FinanceCSECreditAmounts.January) ? data[FinanceCSECreditAmounts.January].ToString() : null;
            siteModel.February = data.ContainsKey(FinanceCSECreditAmounts.February) ? data[FinanceCSECreditAmounts.February].ToString() : null;
            siteModel.March = data.ContainsKey(FinanceCSECreditAmounts.March) ? data[FinanceCSECreditAmounts.March].ToString() : null;
            siteModel.April = data.ContainsKey(FinanceCSECreditAmounts.April) ? data[FinanceCSECreditAmounts.April].ToString() : null;
            siteModel.May = data.ContainsKey(FinanceCSECreditAmounts.May) ? data[FinanceCSECreditAmounts.May].ToString() : null;
            siteModel.June = data.ContainsKey(FinanceCSECreditAmounts.June) ? data[FinanceCSECreditAmounts.June].ToString() : null;
            siteModel.July = data.ContainsKey(FinanceCSECreditAmounts.July) ? data[FinanceCSECreditAmounts.July].ToString() : null;
            siteModel.August = data.ContainsKey(FinanceCSECreditAmounts.August) ? data[FinanceCSECreditAmounts.August].ToString() : null;
            siteModel.September = data.ContainsKey(FinanceCSECreditAmounts.September) ? data[FinanceCSECreditAmounts.September].ToString() : null;
            siteModel.October = data.ContainsKey(FinanceCSECreditAmounts.October) ? data[FinanceCSECreditAmounts.October].ToString() : null;
            siteModel.November = data.ContainsKey(FinanceCSECreditAmounts.November) ? data[FinanceCSECreditAmounts.November].ToString() : null;
            siteModel.December = data.ContainsKey(FinanceCSECreditAmounts.December) ? data[FinanceCSECreditAmounts.December].ToString() : null;
            return siteModel;
        }

    }
}