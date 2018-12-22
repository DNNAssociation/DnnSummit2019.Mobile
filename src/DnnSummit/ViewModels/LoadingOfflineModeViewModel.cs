using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace DnnSummit.ViewModels
{
    public class LoadingOfflineModeViewModel : BindableBase, INavigatingAware
    {
        private const string OfflineMessage_Pattern = "Unable to update content, information current as of {0}, Contact event staff for any change or retry with internet.";

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

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            Message = string.Format(OfflineMessage_Pattern, date);
        }
    }
}
