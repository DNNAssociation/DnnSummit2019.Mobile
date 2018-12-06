using Newtonsoft.Json;
using System.Collections.Generic;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Session : Entity
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("VideoLink")]
        public string VideoLink { get; set; }

        [JsonProperty("TimeSlot")]
        public string TimeSlot { get; set; }

        [JsonProperty("Day")]
        public string Day { get; set; }

        [JsonProperty("Abstract")]
        public string Abstract { get; set; }

        [JsonProperty("Level")]
        public string Level { get; set; }

        [JsonProperty("Room")]
        public string Room { get; set; }

        [JsonProperty("Speaker")]
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
