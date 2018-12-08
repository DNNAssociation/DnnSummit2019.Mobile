using System.Collections.Generic;

namespace DnnSummit.Data.Models
{
    public class Speaker
    {
        public string Name { get; set; }
        public string Twitter { get; set; }
        public string Bio { get; set; }
        public string PhotoLink { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
    }
}
