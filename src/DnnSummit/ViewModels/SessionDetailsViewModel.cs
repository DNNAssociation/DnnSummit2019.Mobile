using DnnSummit.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace DnnSummit.ViewModels
{
    public class SessionDetailsViewModel : BindableBase, INavigatingAware
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
                RaisePropertyChanged(nameof(Description));
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            var isSuccessful = false;

            if (parameters.ContainsKey(nameof(Session)))
            {
                var session = (Session)parameters[nameof(Session)];
                if (session != null)
                {
                    Title = session.Title;
                    Description = session.Description;

                    isSuccessful = true;
                }
            }

            if (!isSuccessful)
            {
                // TODO - Add some error page loading sequence
            }
        }
    }
}
