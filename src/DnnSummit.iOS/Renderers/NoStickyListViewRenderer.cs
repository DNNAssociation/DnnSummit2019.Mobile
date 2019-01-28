using System;
using CoreGraphics;
using DnnSummit.Controls;
using DnnSummit.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoStickyListView), typeof(NoStickyListViewRenderer))]
namespace DnnSummit.iOS.Renderers
{
    public class NoStickyListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TableHeaderView = new UIView(new CGRect(0, 0, Control.TableHeaderView.Bounds.Width, 140));
                Control.ContentInset = new UIEdgeInsets(-50, 0, 0, 0);
                SetNativeControl(Control);
            }
        }
    }
}
