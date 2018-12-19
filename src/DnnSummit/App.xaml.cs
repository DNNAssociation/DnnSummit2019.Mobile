﻿using DnnSummit.Views;
using Prism;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DnnSummit
{
    public partial class App : PrismApplication
    {
        public const string Dashboard = "/" + Constants.Navigation.NavigationPage + "/" + Constants.Navigation.TabbedPage;
        public const string EntryPoint = "/" + Constants.Navigation.LoadingPage;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Data.Startup.Initialize();

            // TODO - determine most effecient way to do data pull
            // new plan 1. Create a loading page this could be a re-used splash
            //          2. Using INavigatingAware load everything
            //          3. Once done loading we navigate to the main page
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Data.Startup.SyndDataAsync(Container);
            }

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(FindViewModel);
            NavigationService.NavigateAsync(EntryPoint);
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterNavigation(containerRegistry);
            RegisterDependencies(containerRegistry);
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoadingPage>(Constants.Navigation.LoadingPage);
            containerRegistry.RegisterForNavigation<DnnSummitNavigationPage>(Constants.Navigation.NavigationPage);
            containerRegistry.RegisterForNavigation<DnnSummitTabbedPage>(Constants.Navigation.TabbedPage);
            containerRegistry.RegisterForNavigation<LocationPage>(Constants.Navigation.LocationPage);
            containerRegistry.RegisterForNavigation<ScheduleDetailsPage>(Constants.Navigation.ScheduleDetailsPage);
            containerRegistry.RegisterForNavigation<SessionDetailsPage>(Constants.Navigation.SessionDetailsPage);
            containerRegistry.RegisterForNavigation<SponsorsPage>(Constants.Navigation.SponsorsPage);
            Data.Startup.RegisterDependencies(containerRegistry);
        }

        private void RegisterDependencies(IContainerRegistry containerRegistry)
        {
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
