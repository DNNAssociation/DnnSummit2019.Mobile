#if (RELEASE || AD_HOC)
#define APPCENTER
#endif

using System;
using System.Globalization;
using System.Reflection;
using DnnSummit.Manager;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Views;
using MonkeyCache.SQLite;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DnnSummit
{
    public partial class App : PrismApplication
    {
        public const string OfflineLoading = "/" + Constants.Navigation.LoaddingOfflineModePage;
        public const string InternetLoading = "/" + Constants.Navigation.LoadingPage;
        public const string EntryPoint = "/" + Constants.Navigation.NavigationPage + "/" + Constants.Navigation.TabbedPage;
        public static bool DisplayOfflineNotice = true;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var appCenter = Container.Resolve<IAppCenterManager>();
            appCenter.Initialize();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(FindViewModel);

            bool hasDownloadPermission = Device.RuntimePlatform == Device.iOS ? false : true; // need to updaqte this to iOS

            var isExpired = Barrel.Current.IsExpired(Constants.Settings.DownloadPermission);
            if (!hasDownloadPermission && Barrel.Current.Exists(Constants.Settings.DownloadPermission))
            {
                hasDownloadPermission = Barrel.Current.Get<bool>(Constants.Settings.DownloadPermission);
            }

            if (hasDownloadPermission)
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    NavigationService.NavigateAsync(InternetLoading);
                }
                else
                {
                    NavigationService.NavigateAsync(OfflineLoading);
                }
            }
            else
            {
                NavigationService.NavigateAsync(Constants.Navigation.PermissionPage);
            }
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Data.DataModule>(InitializationMode.WhenAvailable);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterNavigation(containerRegistry);
            RegisterDependencies(containerRegistry);
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoadingPage>(Constants.Navigation.LoadingPage);
            containerRegistry.RegisterForNavigation<LoadingOfflineModePage>(Constants.Navigation.LoaddingOfflineModePage);
            containerRegistry.RegisterForNavigation<DnnSummitNavigationPage>(Constants.Navigation.NavigationPage);
            containerRegistry.RegisterForNavigation<DnnSummitTabbedPage>(Constants.Navigation.TabbedPage);
            containerRegistry.RegisterForNavigation<VenuePage>(Constants.Navigation.VenuePage);
            containerRegistry.RegisterForNavigation<ScheduleDetailsPage>(Constants.Navigation.ScheduleDetailsPage);
            containerRegistry.RegisterForNavigation<SessionDetailsPage>(Constants.Navigation.SessionDetailsPage);
            containerRegistry.RegisterForNavigation<SponsorsPage>(Constants.Navigation.SponsorsPage);
            containerRegistry.RegisterForNavigation<SchedulePage>(Constants.Navigation.SchedulePage);
            containerRegistry.RegisterForNavigation<CreditsPage>(Constants.Navigation.CreditsPage);
            containerRegistry.RegisterForNavigation<FeedbackPage>(Constants.Navigation.FeedbackPage);
            containerRegistry.RegisterForNavigation<CompletePage>(Constants.Navigation.CompletePage);
            containerRegistry.RegisterForNavigation<PermissionPage>(Constants.Navigation.PermissionPage);
        }

        private void RegisterDependencies(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISecretsManager, SecretsManager>();
            containerRegistry.Register<IAppCenterManager, AppCenterManager>();
            containerRegistry.Register<IErrorRetryManager, ErrorRetryManager>();
        }

        // Page/ViewModel Wireup Logic
        //                Page - FooPage
        //                ViewModel - FooViewModel
        private Type FindViewModel(Type viewType)
        {
            var viewName = viewType.FullName
                .Replace("Page", string.Empty)
                .Replace("Views", "ViewModels");

            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);

            return Type.GetType(viewModelName);
        }
    }
}
