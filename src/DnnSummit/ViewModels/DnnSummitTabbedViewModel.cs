using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class DnnSummitTabbedViewModel : BindableBase
    {
        protected INavigationService NavigationService { get; }
        public DnnSummitTabbedViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            Info = new DelegateCommand(OnInfo);
        }

        
        public ICommand Info { get; }

        private async void OnInfo()
        {
            await NavigationService.NavigateAsync(Constants.Navigation.LocationPage);
        }
    }
}
