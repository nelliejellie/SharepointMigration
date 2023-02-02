using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class DesignCenterDataService : SiteService<DesignCenterDataModel> , IDesignCenterDataService
    {
        public DesignCenterDataService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:DesignCenterData:SiteId"];
            _listId = _configuration["SharePointList:DesignCenterData:ListId"];
            _keyField = DesignCenterData.JobLookup;
        }

        protected override Dictionary<string, object> BuildDictionary(DesignCenterDataModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(DesignCenterData.JobLookup, data.JobLookup);
            dict.Add(DesignCenterData.UpgradeAmount, data.UpgradeAmount);
            dict.Add(DesignCenterData.AllowanceAmount, data.AllowanceAmount);
            dict.Add(DesignCenterData.InvoiceNumber, data.InvoiceNumber);
            dict.Add(DesignCenterData.InvoiceDate, data.InvoiceDate);
            dict.Add(DesignCenterData.InvoiceAmount, data.InvoiceAmount);
            dict.Add(DesignCenterData.InvoiceNotes, data.InvoiceNotes);
            dict.Add(DesignCenterData.Title, data.Title);
            return dict;
        }

        protected override DesignCenterDataModel ToSiteModel(DesignCenterDataModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.JobLookup = data.ContainsKey(DesignCenterData.JobLookup) ? data[DesignCenterData.JobLookup].ToString() : null;
            siteModel.UpgradeAmount = data.ContainsKey(DesignCenterData.UpgradeAmount) ? data[DesignCenterData.UpgradeAmount].ToString() : null;
            siteModel.AllowanceAmount = data.ContainsKey(DesignCenterData.AllowanceAmount) ? data[DesignCenterData.AllowanceAmount].ToString() : null;
            siteModel.InvoiceNumber = data.ContainsKey(DesignCenterData.InvoiceNumber) ? data[DesignCenterData.InvoiceNumber].ToString() : null;
            siteModel.InvoiceDate = data.ContainsKey(DesignCenterData.InvoiceDate) ? (DateTime)data[DesignCenterData.InvoiceDate] : null;
            siteModel.InvoiceAmount = data.ContainsKey(DesignCenterData.InvoiceAmount) ? data[DesignCenterData.InvoiceAmount].ToString() : null;
            siteModel.InvoiceNotes = data.ContainsKey(DesignCenterData.InvoiceNotes) ? data[DesignCenterData.InvoiceNotes].ToString() : null;
            siteModel.Title = data.ContainsKey(DesignCenterData.Title) ? data[DesignCenterData.Title].ToString() : null;
            
            return siteModel;
        }

    }
}