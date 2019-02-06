using DnnSummit.Data.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class EndpointService : IEndpointService
    {
        public async Task<bool> PostAsync<TRequest>(string route, TRequest input)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(route);
            client.Timeout = TimeSpan.FromSeconds(30);

            var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(string.Empty, content);

            return result.IsSuccessStatusCode;
        }
    }
}
