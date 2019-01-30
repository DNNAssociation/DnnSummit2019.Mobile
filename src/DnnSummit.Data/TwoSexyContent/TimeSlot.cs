using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class TimeSlot : Entity
    {
        [JsonProperty("DisplayName")]
        public string Name { get; set; }

        [JsonProperty("DisplayTime")]
        public string Time { get; set; }

        [JsonProperty("Day")]
        public string Day { get; set; }
    }
}
