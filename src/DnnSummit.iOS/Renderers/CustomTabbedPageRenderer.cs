using System;
using CoreImage;
using DnnSummit.Controls;
using DnnSummit.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace DnnSummit.iOS.Renderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        private UIColor _unselectedColor = UIColor.FromRGB(114, 113, 38);

        public override void ViewWillAppear(bool animated)
        {
            TabBar.UnselectedItemTintColor = _unselectedColor;
            TabBar.SelectedImageTintColor = UIColor.White;
            TabBar.TintColor = UIColor.White;

            if (TabBar?.Items == null) return;

            var tabs = Element as TabbedPage;
            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                {
                    UpdateItem(TabBar.Items[i]);
                }
            }

            base.ViewWillAppear(animated);
        }

        private void UpdateItem(UITabBarItem item)
        {
            if (item == null) return;
            
            item.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White
            }, UIControlState.Selected); 
            
        }
    }
}
