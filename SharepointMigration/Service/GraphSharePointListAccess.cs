using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Helper;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public class GraphSharePointListAccess : GraphSharePointAccess, IGraphSharePointListAccess
    {
        public GraphSharePointListAccess(ITokenService tokenService, IConfiguration config, IMemoryCache memoryCache) :
            base(tokenService,config, memoryCache)
        {
        }


        public async Task<IListItemsCollectionPage> Get(string siteId, string listId, string filter = null, string orderBy = null, string expand = null)
        {
            var queryOptions = new List<QueryOption>()
            {
                new QueryOption("expand", expand ?? "fields"),
                new QueryOption("top", "1000")
            };

            if (!string.IsNullOrEmpty(filter))
                queryOptions.Add(new QueryOption("filter", filter));

            if (!string.IsNullOrEmpty(orderBy))
                queryOptions.Add(new QueryOption("orderby", orderBy));


            return await Retry.DoAsync<IListItemsCollectionPage>(async () => await _graphServiceClient.Sites[siteId]
                    .Lists[listId]
                    .Items
                    .Request(queryOptions)
                    .Header("Prefer", "HonorNonIndexedQueriesWarningMayFailRandomly")
                    .GetAsync()
                , 10000, 1);
        }

        public async Task<FieldValueSet> Patch(string siteId, string listId, string itemId, Dictionary<string, object> dictItem)
        {
            return await Retry.DoAsync<FieldValueSet>(async () =>
            {
                var fieldValueSet = new FieldValueSet() { AdditionalData = dictItem };
                
                return await _graphServiceClient
                    .Sites[siteId]
                    .Lists[listId]
                    .Items[itemId]
                    .Fields
                    .Request()
                    .UpdateAsync(fieldValueSet);
            }, 10000, 1);
        }

        public async Task<ListItem> Post(string siteId, string listId, Dictionary<string, object> additionalDataDictionary)
        {
            return await Retry.DoAsync(async () =>
            {
                var fieldValueSet = new FieldValueSet() { AdditionalData = additionalDataDictionary };
                var listItem = new ListItem { Fields = fieldValueSet };

                return await _graphServiceClient
                    .Sites[siteId]
                    .Lists[listId]
                    .Items
                    .Request()
                    .AddAsync(listItem);
            }, 10000, 1);
        }
        public async void Delete(string siteId, string listId, string itemId)
        {
            await _graphServiceClient
                .Sites[siteId]
                .Lists[listId]
                .Items[itemId]
                .Request()
                .DeleteAsync();
        }

        public string GetListItemValue(ListItem listItem, string columnName)
        {
            var data = listItem.Fields.AdditionalData;
            return data.ContainsKey(columnName) ? data[columnName].ToString() : null;
        }
    }
}