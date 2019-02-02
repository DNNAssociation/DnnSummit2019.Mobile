using Newtonsoft.Json;
using System.Collections.Generic;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Itinerary : Entity
    {
        [JsonProperty]
        public IEnumerable<ItineraryMessage> Messages { get; set; }
    }
}
