using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V4.View;
using DnnSummit.Controls;
using DnnSummit.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace DnnSummit.Droid.Renderers
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        private bool _isConfigured = false;
        private ViewPager _pager;
        private TabLayout _layout;


        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (_isConfigured) return;

            if (e.PropertyName == "Renderer")
            {
                _pager = (ViewPager)ViewGroup.GetChildAt(0);
                _layout = (TabLayout)ViewGroup.GetChildAt(1);
                _isConfigured = true;

                ColorStateList colors = null;
                if ((int)Build.VERSION.SdkInt >= 23)
                {
                    colors = Resources.GetColorStateList(Resource.Color.icon_tab, Context.Theme);
                }
                else
                {
                    colors = Resources.GetColorStateList(Resource.Color.icon_tab);
                }

                for (int i = 0; i < _layout.TabCount; i++)
                {
                    var tab = _layout.GetTabAt(i);
                    var icon = tab.Icon;

                    if (icon != null)
                    {
                        icon = DrawableCompat.Wrap(icon);
                        DrawableCompat.SetTintList(icon, colors);
                    }
                }
            }
        }
    }
}
