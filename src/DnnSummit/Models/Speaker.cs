using System.Collections.Generic;
using Xamarin.Forms;

namespace DnnSummit.Models
{
    public class Speaker
    {
        public string Name { get; set; }
        public ImageSource Headshot { get; set; }
        public string Bio { get; set; }
        public IEnumerable<Session> Sessions { get; set; }

    }
}
