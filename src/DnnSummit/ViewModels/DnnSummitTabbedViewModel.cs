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

            Location = new DelegateCommand(OnLocation);
        }

        
        public ICommand Location { get; }

        private async void OnLocation()
        {
            await NavigationService.NavigateAsync(Constants.Navigation.LocationPage);
        }
    }
}
