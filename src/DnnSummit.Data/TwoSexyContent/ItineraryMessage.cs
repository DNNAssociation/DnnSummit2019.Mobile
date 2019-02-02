using Newtonsoft.Json;
using System.Collections.Generic;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class ItineraryMessage : Entity
    {
        [JsonProperty]
        public string Heading { get; set; }

        [JsonProperty]
        public string SubHeading { get; set; }

        [JsonProperty]
        public IEnumerable<ItineraryEvent> Events { get; set; }
    }
}
