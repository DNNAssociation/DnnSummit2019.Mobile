using System.Collections.Generic;

namespace DnnSummit.Models
{
    public class Speaker
    {
        public string Name { get; set; }
        public string HeadshotImage { get; set; }
        public string Bio { get; set; }
        public IEnumerable<Session> Sessions { get; set; }

    }
}
