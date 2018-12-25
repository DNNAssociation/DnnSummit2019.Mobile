using Xamarin.Forms;

namespace DnnSummit.Models
{
    public class Sponsor
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public string Homepage { get; set; }
        public SponsorType Level { get; set; }
    }
}
