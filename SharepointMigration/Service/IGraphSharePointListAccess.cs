using Microsoft.Graph;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IGraphSharePointListAccess
    {
        Task<IListItemsCollectionPage> Get(string siteId, string listId, string filter = null, string orderBy = null, string expand = null);

        Task<FieldValueSet> Patch(string siteId, string listId, string itemId,
            Dictionary<string, object> dictItem);

        Task<ListItem> Post(string siteId, string listId, Dictionary<string, object> additionalDataDictionary);
        void Delete(string siteId, string listId, string itemId);

        string GetListItemValue(ListItem listItem, string columnName);
    }
}