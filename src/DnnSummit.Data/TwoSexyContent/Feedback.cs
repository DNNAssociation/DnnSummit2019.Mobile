using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Feedback : Entity
    {
        [JsonProperty]
        public string Question { get; set; }

        [JsonProperty]
        public string Help { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public int Order { get; set; }
    }
}
