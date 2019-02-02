using System.Collections.Generic;

namespace DnnSummit.Models
{
    public class Day
    {
        public string Title { get; set; }
        public IEnumerable<DayMessage> Messages { get; set; }
    }
}
