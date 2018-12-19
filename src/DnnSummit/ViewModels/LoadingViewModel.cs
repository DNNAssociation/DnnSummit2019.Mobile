using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace DnnSummit.ViewModels
{
    public class LoadingViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }

        private double _percentCompleted;
        public double PercentCompleted
        {
            get { return _percentCompleted; }
            set
            {
                SetProperty(ref _percentCompleted, value);
                RaisePropertyChanged(nameof(PercentCompleted));
            }
        }
        
        public LoadingViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private async Task DownloadAsync()
        {
            Data.Startup.ProgressUpdated += OnProgressUpdated;
            await Data.Startup.SyndDataAsync(App.Current.Container);
            Data.Startup.ProgressUpdated -= OnProgressUpdated;

            await Task.Delay(1000); // makes sure the animation completes before navigating to the dashboard
            await NavigationService.NavigateAsync(App.Dashboard);
        }

        private void OnProgressUpdated(object sender, EventArgs e)
        {
            PercentCompleted = (double)sender;
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            PercentCompleted = 0.0d;
            await DownloadAsync();
        }
    }
}
