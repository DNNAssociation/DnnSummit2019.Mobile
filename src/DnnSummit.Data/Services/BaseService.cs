using DnnSummit.Data.TwoSexyContent;
using MonkeyCache.SQLite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DnnSummit.Data.Services
{
    internal abstract class BaseService<TEntity, TModel>
    {
        protected HttpClient Client { get; }
        protected string Method { get; }
        protected BaseService(string endpoint, string method)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(endpoint);
            Method = method;
        }

        public virtual async Task SyncAsync()
        {
            await GetAsync(true);
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync(bool forceRefresh = false)
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet ||
                    (!forceRefresh && !Barrel.Current.IsExpired(Method)))
                {
                    var cachedJson = Barrel.Current.Get<string>(Method);
                    var result = JsonConvert.DeserializeObject<IEnumerable<TModel>>(cachedJson);
                    if (result != null || result.Any())
                        return result;
                }

                var data = await QueryAndMapAsync();
                Barrel.Current.Add(Method, JsonConvert.SerializeObject(data), TimeSpan.FromDays(5));

                return data;
            }
            catch (Exception)
            {
                // something went wrong we should pull from local database if possible
                var cachedJson = Barrel.Current.Get<string>(Method);
                if (!string.IsNullOrEmpty(cachedJson))
                {
                    var cached = JsonConvert.DeserializeObject<IEnumerable<TModel>>(cachedJson);
                    return cached;
                }
            }

            return default(IEnumerable<TModel>);
        }

        protected abstract Task<IEnumerable<TModel>> QueryAndMapAsync();

        protected Task<IEnumerable<TEntity>> QueryAsync()
        {
            // this pulls back only published data
            return QueryAsync<TEntity>(Method);
        }

        protected async Task<IEnumerable<TCustom>> QueryAsync<TCustom>(string method)
        {
            var response = await Client.GetAsync(method);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<QueryModel<TCustom>>(json);

                return model.Default;
            }

            return null;
        }
    }
}
