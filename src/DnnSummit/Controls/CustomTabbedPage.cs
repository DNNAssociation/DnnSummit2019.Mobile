using Xamarin.Forms;

namespace DnnSummit.Controls
{
    public class CustomTabbedPage : TabbedPage
    {
        public Color SelectedIconColor
        {
            get { return (Color)GetValue(SelectedIconColorProperty); }
            set { SetValue(SelectedIconColorProperty, value); }
        }

        public static readonly BindableProperty SelectedIconColorProperty = BindableProperty.Create(
            nameof(SelectedItemProperty),
            typeof(Color),
            typeof(CustomTabbedPage),
            Color.White);

        public Color UnselectedIconColor
        {
            get { return (Color)GetValue(UnelectedIconColorProperty); }
            set { SetValue(UnelectedIconColorProperty, value); }
        }

        public static readonly BindableProperty UnelectedIconColorProperty = BindableProperty.Create(
            nameof(UnselectedIconColor),
            typeof(Color),
            typeof(CustomTabbedPage),
            Color.White);
    }
}
