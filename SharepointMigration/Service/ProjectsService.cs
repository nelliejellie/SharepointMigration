using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public class ProjectsService : SiteService<ProjectsModel> , IProjectsService
    {
        public ProjectsService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:Projects:SiteId"];
            _listId = _configuration["SharePointList:Projects:ListId"];
            _keyField = Projects.Number;
        }

        protected override Dictionary<string, object> BuildDictionary(ProjectsModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(Projects.Title, data.Title);
            dict.Add(Projects.Number, data.Number);
            dict.Add(Projects.Market, data.Market);
            dict.Add(Projects.Brand, data.Brand);
            return dict;
        }

        protected override ProjectsModel ToSiteModel(ProjectsModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;
            siteModel.Title = data.ContainsKey(Projects.Title) ? data[Projects.Title].ToString() : null;
            siteModel.Number = data.ContainsKey(Projects.Number) ? data[Projects.Number].ToString() : null;
            siteModel.Market = data.ContainsKey(Projects.Market) ? data[Projects.Market].ToString() : null;
            siteModel.Brand = data.ContainsKey(Projects.Brand) ? data[Projects.Brand].ToString() : null;
            return siteModel;
        }

    }
}