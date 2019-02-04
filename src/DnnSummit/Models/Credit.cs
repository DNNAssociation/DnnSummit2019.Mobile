using Xamarin.Forms;

namespace DnnSummit.Models
{
    public class Credit
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Logo { get; set; }
        public string Website { get; set; }
        public CreditType CreditType { get; set; }
        public bool IncludeTitle { get; set; }
    }
}
