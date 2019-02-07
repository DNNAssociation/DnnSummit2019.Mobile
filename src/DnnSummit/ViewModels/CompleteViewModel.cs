using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class CompleteViewModel : BindableBase, INavigatingAware
    {
        private bool _isGoBackToRoot;
        protected INavigationService NavigationService { get; }
        public CompleteViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Submit = new DelegateCommand(OnSubmit);
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
                RaisePropertyChanged(nameof(Title));
            }
        }

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

        private string _summary;
        public string Summary
        {
            get { return _summary; }
            set
            {
                SetProperty(ref _summary, value);
                RaisePropertyChanged(nameof(Summary));
            }
        }

        public ICommand Submit { get; }

        private async void OnSubmit()
        {
            if (_isGoBackToRoot)
            {
                await NavigationService.GoBackToRootAsync();
            }
            else
            {
                await NavigationService.GoBackAsync();
            }
        }


        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Title = "Complete";

            if (parameters.ContainsKey(Constants.Navigation.Parameters.GoBackToRoot))
            {
                var goBackToRoot = (bool?)parameters[Constants.Navigation.Parameters.GoBackToRoot];
                if (goBackToRoot.HasValue)
                {
                    _isGoBackToRoot = goBackToRoot.Value;
                }

                _isGoBackToRoot = true;
            }

            if (parameters.ContainsKey(Constants.Navigation.Parameters.Title))
            {
                var title = (string)parameters[Constants.Navigation.Parameters.Title];
                if (!string.IsNullOrWhiteSpace(title))
                {
                    Title = title;
                }
            }

            if (parameters.ContainsKey(Constants.Navigation.Parameters.Complete))
            {
                var model = (Complete)parameters[Constants.Navigation.Parameters.Complete];
                if (model != null)
                {
                    Message = model.Message;
                    Summary = model.Summary;
                }
            }
        }
    }
}
