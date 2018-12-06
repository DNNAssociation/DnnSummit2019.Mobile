using Newtonsoft.Json;
using System.Collections.Generic;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    public class QueryModel<TModel>
    {
        [JsonProperty("Default")]
        public IEnumerable<TModel> Default { get; set; }
    }
}
