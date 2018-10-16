using DnnSummit.Views;
using Prism;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DnnSummit
{
    public partial class App : PrismApplication
    {
        public const string EntryPoint = "/" + Constants.Navigation.NavigationPage + "/" + Constants.Navigation.TabbedPage;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }


        protected async override void OnInitialized()
        {
            InitializeComponent();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(FindViewModel);
            await NavigationService.NavigateAsync(EntryPoint);
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterNavigation(containerRegistry);
            RegisterDependencies(containerRegistry);
        }

        private void RegisterNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DnnSummitNavigationPage>(Constants.Navigation.NavigationPage);
            containerRegistry.RegisterForNavigation<DnnSummitTabbedPage>(Constants.Navigation.TabbedPage);
            containerRegistry.RegisterForNavigation<MainPage>(Constants.Navigation.MainPage);
        }

        private void RegisterDependencies(IContainerRegistry containerRegistry)
        {
        }

        // REVIEW - Will: Please review this block of code and if you have issues with it we can discuss.
        //                This was added to simplify the convention between Page/ViewModel.
        //              
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
