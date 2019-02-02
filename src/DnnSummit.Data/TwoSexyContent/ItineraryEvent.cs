using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class ItineraryEvent : Entity
    {
        [JsonProperty]
        public string TimeSlot { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string Room { get; set; }
    }
}
