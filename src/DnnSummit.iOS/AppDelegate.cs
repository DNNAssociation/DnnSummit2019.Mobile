﻿using System.Diagnostics;
using CarouselView.FormsPlugin.iOS;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using UIKit;
using Xamarin.Forms.Internals;

namespace DnnSummit.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

            ImageCircleRenderer.Init();
            CarouselViewRenderer.Init();

#if DEBUG
            Log.Listeners.Add(new DelegateLogListener((c, e) => Debug.WriteLine(e)));
#endif
            LoadApplication(new App());



            return base.FinishedLaunching(app, options);
        }
    }
}
