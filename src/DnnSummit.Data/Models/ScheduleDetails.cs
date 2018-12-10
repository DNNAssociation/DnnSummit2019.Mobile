using System.Collections.Generic;

namespace DnnSummit.Data.Models
{
    public class ScheduleDetails
    {
        public string Title { get; set; }
        public string CardDescription { get; set; }
        public string BannerTitle { get; set; }
        public string BannerHeading { get; set; }
        public IEnumerable<Content> Sections { get; set; }
    }
}
