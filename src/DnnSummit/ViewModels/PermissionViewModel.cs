using MonkeyCache.SQLite;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Essentials;

namespace DnnSummit.ViewModels
{
    public class PermissionViewModel : BindableBase
    {
        public string Title => "App Permissions";

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

        public ICommand Approve { get; }
        public ICommand DontApprove { get; }

        private bool _isDeny;
        public bool IsDeny
        {
            get { return _isDeny; }
            set
            {
                SetProperty(ref _isDeny, value);
                RaisePropertyChanged(nameof(IsDeny));
            }
        }

        protected INavigationService NavigationService { get; }
        public PermissionViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Approve = new DelegateCommand(OnApprove);
            DontApprove = new DelegateCommand(OnDontApprove);
            IsDeny = false;
            Message = "The App requires permission to download additional content for the app to function correctly. By clicking Approve you will download about 400 KB of additional content and it is recommended to do this over wi-fi";
        }

        private void OnDontApprove()
        {
            IsDeny = true;
            Message = "The app will not function without the ability to download additional content onto your device";
        }

        private async void OnApprove()
        {
            if (Barrel.Current.Exists(Constants.Settings.DownloadPermission))
            {
                Barrel.Current.Empty(Constants.Settings.DownloadPermission);
            }

            Barrel.Current.Add(Constants.Settings.DownloadPermission, true, TimeSpan.FromDays(100));
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await NavigationService.NavigateAsync(App.InternetLoading);
            }
            else
            {
                await NavigationService.NavigateAsync(App.OfflineLoading);
            }
        }
    }
}
