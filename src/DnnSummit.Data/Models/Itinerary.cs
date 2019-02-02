using System.Collections.Generic;

namespace DnnSummit.Data.Models
{
    public class Itinerary
    {
        public string Title { get; set; }
        public IEnumerable<ItineraryMessage> Messages { get; set; }
    }
}
