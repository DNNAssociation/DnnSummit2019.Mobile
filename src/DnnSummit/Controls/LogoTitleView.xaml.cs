using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnnSummit.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogoTitleView : ContentView
	{
		public LogoTitleView ()
		{
			InitializeComponent ();
		}

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(LogoTitleView),
            null,
            propertyChanged: OnTitlePropertyChanged);

        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (LogoTitleView)bindable;
            if (context != null)
            {
                context.TitleLabel.Text = (string)newValue;
            }
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            nameof(Source),
            typeof(ImageSource),
            typeof(LogoTitleView),
            null,
            propertyChanged: OnSourcePropertyChanged);

        private static void OnSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (LogoTitleView)bindable;
            if (context != null)
            {
                context.IconImage.Source = (ImageSource)newValue;
            }
        }
    }
}