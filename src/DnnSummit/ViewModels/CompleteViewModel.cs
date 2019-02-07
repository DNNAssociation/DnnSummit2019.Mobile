using Prism.Mvvm;
using Prism.Navigation;

namespace DnnSummit.ViewModels
{
    public class CompleteViewModel : BindableBase, INavigatingAware
    {
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


        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Title = "Survey";
            Message = "Survey Complete!";
            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque sed purus ligula. Proin elementum enim sit amet felis faucibus accumsan. Cras viverra quam turpis, at bibendum lorem.";
        }
    }
}
