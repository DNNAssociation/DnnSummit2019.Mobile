using DnnSummit.Data;
using DnnSummit.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DnnSummit.ViewModels
{
    public class LoadingViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }
        protected IStartupManager StartupManager { get; }
        protected IEventAggregator EventAggregator { get; }

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
        
        public LoadingViewModel(
            INavigationService navigationService,
            IStartupManager startupManager,
            IEventAggregator eventAggregator)
        {
            NavigationService = navigationService;
            StartupManager = startupManager;

            eventAggregator
                .GetEvent<ContentDownloadProgressUpdated>()
                .Subscribe(OnProgressUpdated);
        }

        private async Task DownloadAsync()
        {
            try
            {
                await StartupManager.SyndDataAsync();
                await Task.Delay(1000); // makes sure the animation completes before navigating to the dashboard
            }
            catch (Exception ex)
            {
            }
            finally
            {
                await FinishAndNavigateAsync();
            }
        }

        private async Task FinishAndNavigateAsync()
        {            
            await NavigationService.NavigateAsync(App.EntryPoint);
        }

        private void OnProgressUpdated(double progress)
        {
            PercentCompleted = progress;
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                PercentCompleted = 0.0d;
                await DownloadAsync();
            }
            else
            {
                await FinishAndNavigateAsync();
            }
        }
    }
}
