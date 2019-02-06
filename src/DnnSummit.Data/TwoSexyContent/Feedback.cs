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
        public double Order { get; set; }

        [JsonProperty]
        public bool IsRequired { get; set; }
    }
}
