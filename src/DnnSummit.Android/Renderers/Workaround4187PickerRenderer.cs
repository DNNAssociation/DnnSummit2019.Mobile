using Android.Content;
using DnnSummit.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Picker), typeof(Workaround4187PickerRenderer))]
namespace DnnSummit.Droid.Renderers
{
    public class Workaround4187PickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        public Workaround4187PickerRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Focusable = false;
            }
        }
    }
}