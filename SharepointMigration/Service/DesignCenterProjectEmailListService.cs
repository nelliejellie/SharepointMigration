using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class DesignCenterProjectEmailListService : SiteService<DesignCenterProjectEmailListModel> , IDesignCenterProjectEmailListService
    {
        public DesignCenterProjectEmailListService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:DesignCenterProjectEmailList:SiteId"];
            _listId = _configuration["SharePointList:DesignCenterProjectEmailList:ListId"];
            _keyField = DesignCenterProjectEmailList.ProjectTitle;
        }

        protected override Dictionary<string, object> BuildDictionary(DesignCenterProjectEmailListModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(DesignCenterProjectEmailList.ProjectTitle, data.ProjectTitle);
            dict.Add(DesignCenterProjectEmailList.ProjectNumber, data.ProjectNumber);
            dict.Add(DesignCenterProjectEmailList.DivisionText, data.DivisionText);
            dict.Add(DesignCenterProjectEmailList.Email, data.Email);
           
            return dict;
        }

        protected override DesignCenterProjectEmailListModel ToSiteModel(DesignCenterProjectEmailListModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectTitle = data.ContainsKey(DesignCenterProjectEmailList.ProjectTitle) ? data[DesignCenterProjectEmailList.ProjectTitle].ToString() : null;
            siteModel.ProjectNumber = data.ContainsKey(DesignCenterProjectEmailList.ProjectNumber) ? data[DesignCenterProjectEmailList.ProjectNumber].ToString() : null;
            siteModel.DivisionText = data.ContainsKey(DesignCenterProjectEmailList.DivisionText) ? data[DesignCenterProjectEmailList.DivisionText].ToString() : null;
            siteModel.Email = data.ContainsKey(DesignCenterProjectEmailList.Email) ? data[DesignCenterProjectEmailList.Email].ToString() : null;
            return siteModel;
        }

    }
}