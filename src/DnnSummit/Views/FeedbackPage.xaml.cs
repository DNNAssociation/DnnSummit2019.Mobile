using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnnSummit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listview = (ListView)sender;
            if (listview != null)
            {
                listview.SelectedItem = null;
            }
        }
    }
}