using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class SalesNeedInputService : SiteService<SalesNeedInputModel> , ISalesNeedInputService
    {
        public SalesNeedInputService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:SalesNeedInput:SiteId"];
            _listId = _configuration["SharePointList:SalesNeedInput:ListId"];
            _keyField = SalesNeedInput.ProjectNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(SalesNeedInputModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(SalesNeedInput.ProjectTitle, data.ProjectTitle);
            dict.Add(SalesNeedInput.ProjectNumber, data.ProjectNumber);
            dict.Add(SalesNeedInput.Division, data.Division);
            dict.Add(SalesNeedInput.Notes, data.Notes);
            dict.Add(SalesNeedInput.ProjectedUnits, data.ProjectedUnits);
            dict.Add(SalesNeedInput.BudgetedUnits, data.BudgetedUnits);
            dict.Add(SalesNeedInput.BudgetAvgSalesPrice, data.BudgetAvgSalesPrice);
            dict.Add(SalesNeedInput.BudgetCM, data.BudgetCM);
            return dict;
        }

        protected override SalesNeedInputModel ToSiteModel(SalesNeedInputModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectTitle = data.ContainsKey(SalesNeedInput.ProjectTitle) ? data[SalesNeedInput.ProjectTitle].ToString() : null;
            siteModel.ProjectNumber = data.ContainsKey(SalesNeedInput.ProjectNumber) ? data[SalesNeedInput.ProjectNumber].ToString() : null;
            siteModel.Division = data.ContainsKey(SalesNeedInput.Division) ? data[SalesNeedInput.Division].ToString() : null;
            siteModel.Notes = data.ContainsKey(SalesNeedInput.Notes) ? data[SalesNeedInput.Notes].ToString() : null;
            siteModel.ProjectedUnits = data.ContainsKey(SalesNeedInput.ProjectedUnits) ? data[SalesNeedInput.ProjectedUnits].ToString() : null;
            siteModel.BudgetedUnits = data.ContainsKey(SalesNeedInput.BudgetedUnits) ? data[SalesNeedInput.BudgetedUnits].ToString() : null;
            siteModel.BudgetAvgSalesPrice = data.ContainsKey(SalesNeedInput.BudgetAvgSalesPrice) ? data[SalesNeedInput.BudgetAvgSalesPrice].ToString() : null;
            siteModel.BudgetCM = data.ContainsKey(SalesNeedInput.BudgetCM) ? data[SalesNeedInput.BudgetCM].ToString() : null;
            return siteModel;
        }

    }
}