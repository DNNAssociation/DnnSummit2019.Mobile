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

        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                SetProperty(ref _image, value);
                RaisePropertyChanged(nameof(Image));
            }
        }

        private string _room;
        public string Room
        {
            get { return _room; }
            set
            {
                SetProperty(ref _room, value);
                RaisePropertyChanged(nameof(Room));
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                SetProperty(ref _fullName, value);
                RaisePropertyChanged(nameof(FullName));
            }
        }

        private string _session;
        public string Session
        {
            get { return _session; }
            set
            {
                SetProperty(ref _session, value);
                RaisePropertyChanged(nameof(Session));
            }
        }

        private string _timeSlot;
        public string TimeSlot
        {
            get { return _timeSlot; }
            set
            {
                SetProperty(ref _timeSlot, value);
                RaisePropertyChanged(nameof(TimeSlot));
            }
        }

        private SessionTrack _sessionTrack;
        public SessionTrack SessionTrack
        {
            get { return _sessionTrack; }
            set
            {
                SetProperty(ref _sessionTrack, value);
                RaisePropertyChanged(nameof(SessionTrack));
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
                    Image = session.Speaker.HeadshotImage;
                    Room = session.Room;
                    FullName = session.Speaker.Name;
                    Session = "Session 1";
                    TimeSlot = "9:10-10:10";
                    SessionTrack = session.Track;

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
