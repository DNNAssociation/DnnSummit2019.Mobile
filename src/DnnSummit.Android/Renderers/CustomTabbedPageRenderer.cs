using Android.Content;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using DnnSummit.Controls;
using DnnSummit.Droid.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace DnnSummit.Droid.Renderers
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        private ViewPager pager;
        private TabLayout layout;

        public CustomTabbedPageRenderer(Context context) : base(context) { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            pager = (ViewPager)ViewGroup.GetChildAt(0);
            layout = (TabLayout)ViewGroup.GetChildAt(1);

            var control = (CustomTabbedPage)sender;
            Android.Graphics.Color selectedColor;
            Android.Graphics.Color unselectedColor;
            if (control != null)
            {
                selectedColor = control.SelectedIconColor.ToAndroid();
                unselectedColor = control.UnselectedIconColor.ToAndroid();
            }
            else
            {
                selectedColor = new Android.Graphics.Color(ContextCompat.GetColor(Context, Resource.Color.tabBarSelected));
                unselectedColor = new Android.Graphics.Color(ContextCompat.GetColor(Context, Resource.Color.tabBarUnselected));
            }

            for (int i = 0; i < layout.TabCount; i++)
            {
                var tab = layout.GetTabAt(i);
                var icon = tab.Icon;
                if (icon != null)
                {
                    var color = tab.IsSelected ? selectedColor : unselectedColor;
                    icon = Android.Support.V4.Graphics.Drawable.DrawableCompat.Wrap(icon);
                    icon.SetColorFilter(color, PorterDuff.Mode.SrcIn);
                }
            }
        }
    }
}
