using System;
using System.Collections.Generic;

namespace DnnSummit.Models
{
    public class Event
    {
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public ScheduleType Avatar { get; set; }
        public (string Heading, string SubHeading, byte[] Image) Banner { get; set; }
        public IEnumerable<ScheduleContent> ContentSections { get; set; }
        public DateTime Retrieved { get; set; }
    }
}
