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

            NavigateToSchedule = new DelegateCommand(OnNavigateToSchedule);
        }

        
        public ICommand NavigateToSchedule { get; }

        private async void OnNavigateToSchedule()
        {
            await NavigationService.NavigateAsync(Constants.Navigation.SchedulePage);
        }
    }
}
