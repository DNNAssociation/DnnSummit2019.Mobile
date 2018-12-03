using System.Collections.Generic;

namespace DnnSummit.Models
{
    public class SessionList : List<Session>
    {
        public SessionList() { }
        public SessionList(string heading, string subHeading)
        {
            Heading = heading;
            SubHeading = subHeading;
        }

        public SessionList(string heading, string subHeading, IEnumerable<Session> sessions)
            : this(heading, subHeading)
        {
            AddRange(sessions);
        }

        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public List<Session> Sessions => this;
    }
}
