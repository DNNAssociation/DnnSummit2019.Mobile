using DnnSummit.Data.TwoSexyContent;
using MonkeyCache.SQLite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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

        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            if (!Barrel.Current.IsExpired(Method))
            {
                var cachedJson = Barrel.Current.Get<string>(Method);
                return JsonConvert.DeserializeObject<IEnumerable<TModel>>(cachedJson);
            }

            var data = await QueryAndMapAsync();
            Barrel.Current.Add(Method, JsonConvert.SerializeObject(data), TimeSpan.FromDays(5));

            return data;
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
