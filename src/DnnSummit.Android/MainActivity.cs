using Android.App;
using Android.Content.PM;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using DnnSummit.Droid.Managers;
using DnnSummit.Manager.Interfaces;
using ImageCircle.Forms.Plugin.Droid;
using Prism;
using Prism.Ioc;

namespace DnnSummit.Droid
{
    [Activity(
        Label = "Dnn Summit", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        ConfigurationChanges = ConfigChanges.ScreenSize,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ImageCircleRenderer.Init();
            CarouselViewRenderer.Init();

            LoadApplication(new App(new AppInitializer()));
        }

        private class AppInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                containerRegistry.Register<IFileManager, FileManager>();
            }
        }
    }
}