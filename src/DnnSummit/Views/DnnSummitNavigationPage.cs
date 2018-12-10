using Xamarin.Forms;

namespace DnnSummit.Views
{
    public class DnnSummitNavigationPage : NavigationPage
    {
        public DnnSummitNavigationPage()
        {
            BarBackgroundColor = (Color)Application.Current.Resources["DarkBlue"];
            BarTextColor = (Color)Application.Current.Resources["White"];
        }
    }
}
