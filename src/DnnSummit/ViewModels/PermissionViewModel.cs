using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class PermissionViewModel : BindableBase
    {
        public string Title => "App Permissions";

        public string Message => "DNN Summit 2019 requires permission to download additional content for the app to function correctly.";

        public ICommand Approve { get; }
        public ICommand DontApprove { get; }

        public PermissionViewModel()
        {
            Approve = new DelegateCommand(OnApprove);
            DontApprove = new DelegateCommand(OnDontApprove);
        }

        private void OnDontApprove()
        {
        }

        private void OnApprove()
        {
        }
    }
}
