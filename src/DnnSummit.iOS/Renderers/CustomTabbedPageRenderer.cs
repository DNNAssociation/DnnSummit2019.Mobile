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
        public override void ViewWillAppear(bool animated)
        {
            //TabBar.UnselectedItemTintColor = _unselectedColor;
            //TabBar.SelectedImageTintColor = UIColor.White;
            //TabBar.TintColor = UIColor.White;

            if (TabBar?.Items == null) return;

            var control = (CustomTabbedPage)Element;
            UIColor selectedColor;
            UIColor unselectedColor;
            UIColor selectedTextColor;
            UIColor unselectedTextColor;
            if (control != null)
            {
                selectedColor = control.SelectedIconColor.ToUIColor();
                unselectedColor = control.UnselectedIconColor.ToUIColor();
                selectedTextColor = control.SelectedTextColor.ToUIColor();
                unselectedTextColor = control.UnselectedTextColor.ToUIColor();
            }
            else
            {
                selectedColor = UIColor.White;
                unselectedColor = UIColor.Black;
                selectedTextColor = UIColor.White;
                unselectedTextColor = UIColor.White;
            }

            TabBar.UnselectedItemTintColor = unselectedColor;
            TabBar.SelectedImageTintColor = selectedColor;


            var tabs = Element as TabbedPage;
            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                {
                    UpdateItem(TabBar.Items[i], selectedTextColor, unselectedTextColor);
                }
            }

            base.ViewWillAppear(animated);
        }

        private void UpdateItem(UITabBarItem item, UIColor selected, UIColor unselected)
        {
            if (item == null) return;
            
            item.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = selected
            }, UIControlState.Selected);

            item.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = unselected
            }, UIControlState.Normal);
        }
    }
}
