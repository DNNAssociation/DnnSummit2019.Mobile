using System.Collections.Generic;

namespace DnnSummit.Data.Models
{
    public class ItineraryMessage
    {
        public string Title { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public IEnumerable<ItineraryEvent> Events { get; set; }
    }
}
