using System.Collections.Generic;

namespace DnnSummit.Data.Models
{
    public class ScheduleDetails
    {
        public string Title { get; set; }
        public string Heading { get; set; }
        public IEnumerable<Content> Sections { get; set; }
    }
}
