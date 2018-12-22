using DnnSummit.Data.Services.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;

namespace DnnSummit.ViewModels
{
    public class LoadingOfflineModeViewModel : BindableBase, INavigatingAware
    {
        private const string OfflineMessage_Pattern = "Unable to update content, information current as of {0}, Contact event staff for any change or retry with internet.";
        private const string NoDataMessage = "Unable to download content, retry with internet or contact event staff.";

        protected ISettingsService SettingsService { get; }

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

        public LoadingOfflineModeViewModel(ISettingsService settingsService)
        {
            SettingsService = settingsService;
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
