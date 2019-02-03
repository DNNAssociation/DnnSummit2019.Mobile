using DnnSummit.Data;
using DnnSummit.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace DnnSummit.ViewModels
{
    public class LoadingViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }
        protected IStartupManager StartupManager { get; }
        protected IEventAggregator EventAggregator { get; }

        public ICommand CancelDownload { get; }

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

        private bool _isSkipEnabled;
        public bool IsSkipEnabled
        {
            get { return _isSkipEnabled; }
            set
            {
                SetProperty(ref _isSkipEnabled, value);
                RaisePropertyChanged(nameof(IsSkipEnabled));
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
                RaisePropertyChanged(nameof(IsBusy));
            }
        }
        
        public LoadingViewModel(
            INavigationService navigationService,
            IStartupManager startupManager,
            IEventAggregator eventAggregator)
        {
            NavigationService = navigationService;
            StartupManager = startupManager;

            CancelDownload = new DelegateCommand(OnCancelDownload);

            eventAggregator
                .GetEvent<ContentDownloadProgressUpdated>()
                .Subscribe(OnProgressUpdated);
        }

        private async void OnCancelDownload()
        {
            if (IsBusy) return;

            IsBusy = true;

            StartupManager.CancelDataUpdate();
            await FinishAndNavigateAsync();

            IsBusy = false;
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
                IsSkipEnabled = StartupManager.ContainsData;
                await DownloadAsync();
            }
            else
            {
                await FinishAndNavigateAsync();
            }
        }
    }
}
