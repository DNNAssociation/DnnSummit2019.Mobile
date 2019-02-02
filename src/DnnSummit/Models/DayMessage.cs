using System;
using System.Collections.Generic;
using System.Text;

namespace DnnSummit.Models
{
    public class DayMessage
    {
        public string Title { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public IEnumerable<DayEvent> Events { get; set; }
    }
}
