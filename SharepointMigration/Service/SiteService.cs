using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using SharePointMigration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public abstract class SiteService<T> where T : ISiteModel
    {
        protected readonly IConfiguration _configuration;
        protected readonly IMemoryCache _memoryCache;
        protected readonly IGraphSharePointListAccess _graphSharePointListAccess;

        protected string _siteId;
        protected string _listId;
        protected string _keyField;
        protected string _keyField2;

        public SiteService(IServiceProvider serviceProvider, IConfiguration config, IMemoryCache memoryCache, IGraphSharePointListAccess graphSharePointListAccess)
        {
            _configuration = config;
            _memoryCache = memoryCache;
            _graphSharePointListAccess = graphSharePointListAccess;
        }

        public async Task<List<T>> Get()
        {
            var list = new List<T>();

            var filter = "";

            var result = await _graphSharePointListAccess.Get(_siteId, _listId, filter);

            if (result == null || !result.Any())
            {
                return list;
            }

            foreach (var item in result)
            {
                var record = (T)Activator.CreateInstance(typeof(T));
                record.Id = item.Id;
                record = ToSiteModel(record, item.Fields);
                list.Add(record);
            }

            return list;
        }

        public async Task<T> Get(string key)
        {
            return await _memoryCache.GetOrCreateAsync($"Site1Service.{nameof(Get)}.{key}",
                async (entry) =>
                {
                    var record = (T)Activator.CreateInstance(typeof(T));
                    var filters = new List<string>
                        {$"fields/{_keyField} eq '{key}'"};

                    var filter = string.Join(" and ", filters);

                    var result = await _graphSharePointListAccess.Get(_siteId, _listId, filter);

                    if (result == null || !result.Any())
                    {
                        entry.SetOptions(
                            new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.UtcNow.AddSeconds(1)));
                        return record;
                    }

                    record = ToSiteModel(record, result.First().Fields);
                    record.Id = result.First().Id;
                    entry.SetOptions(
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddSeconds(1))
                    );

                    return record;
                });
        }

        public async Task<T> Get(string key, string key2)
        {
            return await _memoryCache.GetOrCreateAsync($"Site1Service.{nameof(Get)}.{key}",
                async (entry) =>
                {
                    var record = (T)Activator.CreateInstance(typeof(T));
                    var filters = new List<string>
                        {$"fields/{_keyField} eq '{key}'"};
                    filters.Add($"fields/{_keyField2} eq '{key2}'");

                    var filter = string.Join(" and ", filters);

                    var result = await _graphSharePointListAccess.Get(_siteId, _listId, filter);

                    if (result == null || !result.Any())
                    {
                        entry.SetOptions(
                            new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.UtcNow.AddSeconds(1)));
                        return record;
                    }

                    record = ToSiteModel(record, result.First().Fields);
                    record.Id = result.First().Id;
                    entry.SetOptions(
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddSeconds(1))
                    );

                    return record;
                });
        }

        public async Task<T> Update(string key, T data)
        {
            var site1Model = await this.Get(key);

            if (site1Model == null)
            {
                return site1Model;
            }

            Dictionary<string, object> dict = BuildDictionary(data);
            try
            {
                var response = await _graphSharePointListAccess.Patch(_siteId, _listId, site1Model.Id, dict);
                return ToSiteModel(site1Model, response);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return site1Model;
        }

        public async void Create(string key, T data)
        {
            Dictionary<string, object> dict = BuildDictionary(data);

            var response = await _graphSharePointListAccess.Post(_siteId, _listId, dict);
        }

        public async void Delete(string key)
        {
            var site1Model = await this.Get(key);

            if (site1Model == null)
            {
                return;
            }
            _graphSharePointListAccess.Delete(_siteId, _listId, site1Model.Id);
        }

        protected virtual Dictionary<string, object> BuildDictionary(T data)
        {
            var dict = new Dictionary<string, object>();
            return dict;
        }

        protected virtual T ToSiteModel(T site1Model, Entity fieldValueSet)
        {
            var data = fieldValueSet.AdditionalData;

            return site1Model;
        }

    }
}