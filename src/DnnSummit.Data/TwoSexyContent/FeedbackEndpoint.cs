using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class FeedbackEndpoint : Entity
    {
        [JsonProperty]
        public string Endpoint { get; set; }

        [JsonProperty]
        public bool IsEnabled { get; set; }
    }
}
