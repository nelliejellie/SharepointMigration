using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public class SubdivisionSelectionTypeService : SiteService<SubdivisionSelectionTypeModel>, ISubDivisionSelectionTypeService
    {
        public SubdivisionSelectionTypeService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess) : base(serviceProvider, config, memoryCache, graphSharePointListAccess)
        {
            _siteId = _configuration["SharePointList:SubdivisionSelectionType:SiteId"];
            _listId = _configuration["SharePointList:SubdivisionSelectionType:ListId"];
            _keyField = SubdivisionSelectionType.ProjectNumber;
        }


        protected override Dictionary<string, object> BuildDictionary(SubdivisionSelectionTypeModel data)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(SubdivisionSelectionType.ProjectNumber, data.ProjectNumber);
            //dict.Add(SubdivisionSelectionType.Community, data.Community);
            dict.Add(SubdivisionSelectionType.Active, data.Active);
            return dict;
        }

        protected override SubdivisionSelectionTypeModel ToSiteModel(SubdivisionSelectionTypeModel siteModel, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            siteModel.ProjectNumber = data.ContainsKey(SubdivisionSelectionType.ProjectNumber) ? data[BPSProjectDifferential.ProjectNumber].ToString() : null;
            //siteModel.Community = data.ContainsKey(SubdivisionSelectionType.Community) ? data[SubdivisionSelectionType.Community].ToString() : null;
            siteModel.Active = data.ContainsKey(SubdivisionSelectionType.Active) ? data[SubdivisionSelectionType.Active].ToString() : null;

            return siteModel;
        }
    }
}
