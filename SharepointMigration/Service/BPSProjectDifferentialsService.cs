using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class BPSProjectDifferentialsService : SiteService<BPSProjectDifferentialsModel> , IBPSProjectDifferentialsService
    {
        public BPSProjectDifferentialsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:BPSProjectDifferentialsService:SiteId"];
            _listId = _configuration["SharePointList:BPSProjectDifferentialsService:ListId"];
            _keyField = BPSProjectDifferential.ProjectNumber;
        }

        protected override Dictionary<string, object> BuildDictionary(BPSProjectDifferentialsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(BPSProjectDifferential.AmountOffSalesPrice, data.AmountOffSalesPrice);
            dict.Add(BPSProjectDifferential.BaseMargin, data.BaseMargin);
            dict.Add(BPSProjectDifferential.DetachedGarageAmountt, data.DetachedGarageAmount);
            dict.Add(BPSProjectDifferential.DivisionName, data.DivisionName);
            dict.Add(BPSProjectDifferential.FieldMargin, data.FieldMargin);
            dict.Add(BPSProjectDifferential.FSAGarageAmount, data.FSAGarageAmount);
            dict.Add(BPSProjectDifferential.LegalNotice, data.LegalNotice);
            dict.Add(BPSProjectDifferential.LotBaseAmount, data.LotBaseAmount);
            dict.Add(BPSProjectDifferential.LotBasePrepAmount, data.LotBasePrepAmount);
            dict.Add(BPSProjectDifferential.LotOtherAmount, data.LotOtherAmount);
            dict.Add(BPSProjectDifferential.LotOtherPercentage, data.LotOtherPercentage);
            dict.Add(BPSProjectDifferential.LotSize, data.LotSize);
            dict.Add(BPSProjectDifferential.MinimumPlanSqFt, data.MinimumPlanSqFt);
            dict.Add(BPSProjectDifferential.MinMarginn, data.MinMargin);
            dict.Add(BPSProjectDifferential.MMaximumPlanSqFt, data.MMaximumPlanSqFt);
            dict.Add(BPSProjectDifferential.OneStoryAmount, data.OneStoryAmount);
            dict.Add(BPSProjectDifferential.PercentageOffSalePrice, data.PercentageOffSalePrice);
            dict.Add(BPSProjectDifferential.Phase, data.Phase);
            dict.Add(BPSProjectDifferential.ProjectNumber, data.ProjectNumber);
            dict.Add(BPSProjectDifferential.ProjectSort, data.ProjectSort);
            dict.Add(BPSProjectDifferential.RatePlan, data.RatePlan);
            dict.Add(BPSProjectDifferential.TwoStoryAmountt, data.TwoStoryAmount);
            return dict;
        }

        protected override BPSProjectDifferentialsModel ToSiteModel(BPSProjectDifferentialsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectNumber = data.ContainsKey(BPSProjectDifferential.ProjectNumber) ? data[BPSProjectDifferential.ProjectNumber].ToString() : null;
            siteModel.MinMargin = data.ContainsKey(BPSProjectDifferential.MinMarginn) ? data[BPSProjectDifferential.MinMarginn].ToString() : null;
            siteModel.FieldMargin = data.ContainsKey(BPSProjectDifferential.FieldMargin) ? data[BPSProjectDifferential.FieldMargin].ToString() : null;
            siteModel.BaseMargin = data.ContainsKey(BPSProjectDifferential.BaseMargin) ? data[BPSProjectDifferential.BaseMargin].ToString() : null;
            siteModel.PropertyMargin = data.ContainsKey(BPSProjectDifferential.LotSize) ? data[BPSProjectDifferential.LotSize].ToString() : null;
            siteModel.AmountOffSalesPrice = data.ContainsKey(BPSProjectDifferential.AmountOffSalesPrice) ? data[BPSProjectDifferential.AmountOffSalesPrice].ToString() : null;
            siteModel.DetachedGarageAmount = data.ContainsKey(BPSProjectDifferential.DetachedGarageAmountt) ? data[BPSProjectDifferential.DetachedGarageAmountt].ToString() : null;
            siteModel.DivisionName = data.ContainsKey(BPSProjectDifferential.DivisionName) ? data[BPSProjectDifferential.DivisionName].ToString() : null;
            siteModel.FSAGarageAmount = data.ContainsKey(BPSProjectDifferential.FSAGarageAmount) ? data[BPSProjectDifferential.FSAGarageAmount].ToString() : null;
            siteModel.LegalNotice = data.ContainsKey(BPSProjectDifferential.LegalNotice) ? data[BPSProjectDifferential.LegalNotice].ToString() : null;
            return siteModel;
        }

    }
}