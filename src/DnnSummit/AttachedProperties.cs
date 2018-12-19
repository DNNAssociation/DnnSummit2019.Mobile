using Xamarin.Forms;

namespace DnnSummit
{
    public static class AttachedProperties
    {
        public static BindableProperty AnimatedProgressProperty = BindableProperty.CreateAttached(
            "AnimatedProgress",
            typeof(double),
            typeof(ProgressBar),
            0.0d,
            BindingMode.OneWay,
            propertyChanged: OnAnimatedProgressPropertyChanged);

        private static void OnAnimatedProgressPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progressBar = (ProgressBar)bindable;
            if (progressBar != null)
            {
                ViewExtensions.CancelAnimations(progressBar);
                progressBar.ProgressTo((double)newValue, 800, Easing.SinOut);
            }
        }
    }
}
