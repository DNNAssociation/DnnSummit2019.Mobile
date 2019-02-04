using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Credit : Entity
    {
        [JsonProperty]
        public string CreditType { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string Link { get; set; }

        [JsonProperty]
        public string Logo { get; set; }

        [JsonProperty]
        public bool IncludeTitle { get; set; }
    }
}
