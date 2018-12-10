using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using DnnSummit.Controls;
using DnnSummit.Droid.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace DnnSummit.Droid.Renderers
{
    // BUG: SetTint is not working on first load
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        private ViewPager _pager;
        private TabLayout _layout;

        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }
        
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            _pager = (ViewPager)ViewGroup.GetChildAt(0);
            _layout = (TabLayout)ViewGroup.GetChildAt(1);

            for (int i = 0; i < _layout.TabCount; i++)
            {
                var tab = _layout.GetTabAt(i);
                var icon = tab.Icon;

                if (icon != null)
                {
                    if (tab.IsSelected)
                    {
                        icon.SetTint(Resource.Color.tabBarSelected);
                    }
                    else
                    {
                        icon.SetTint(Resource.Color.tabBarUnselected);
                    }
                }
            }
        }
    }
}
