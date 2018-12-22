using DnnSummit.Data.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Essentials;

namespace DnnSummit.ViewModels
{
    public class LoadingOfflineModeViewModel : BindableBase, INavigatingAware
    {
        private const string OfflineMessage_Pattern = "Unable to update content, information current as of {0}, Contact event staff for any change or retry with internet.";
        private const string NoDataMessage = "Unable to download content, retry with internet or contact event staff.";

        protected ISettingsService SettingsService { get; }
        protected IPageDialogService PageDialogService { get; }
        protected INavigationService NavigationService { get; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
                RaisePropertyChanged(nameof(Message));
            }
        }

        private bool _isNoData = false;
        public bool IsNoData
        {
            get { return _isNoData; }
            set
            {
                SetProperty(ref _isNoData, value);
                RaisePropertyChanged(nameof(IsNoData));
            }
        }

        public ICommand DownloadContent { get; }

        public LoadingOfflineModeViewModel(
            ISettingsService settingsService,
            IPageDialogService pageDialogService,
            INavigationService navigationService)
        {
            SettingsService = settingsService;
            PageDialogService = pageDialogService;
            NavigationService = navigationService;
            DownloadContent = new DelegateCommand(OnDownloadContent);
        }

        private async void OnDownloadContent()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await NavigationService.NavigateAsync(App.InternetLoading);
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("No Internet", "Unable to download content, no internet detected.", "OK");
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            var settings = SettingsService.Get();

            if (settings != null)
            {
                IsNoData = false;
                var date = settings.LastUpdated.ToLocalTime().ToString("MM/dd/yyyy");
                Message = string.Format(OfflineMessage_Pattern, date);
            }
            else
            {
                IsNoData = true;
                Message = NoDataMessage;
            }
        }
    }
}
