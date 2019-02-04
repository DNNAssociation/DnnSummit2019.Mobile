using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

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

        private IEnumerable<Speaker> _speakers;
        public IEnumerable<Speaker> Speakers
        {
            get { return _speakers; }
            set
            {
                SetProperty(ref _speakers, value);
                RaisePropertyChanged(nameof(Speakers));
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

        private string _videoIntroLink;
        public string VideoIntroLink
        {
            get { return _videoIntroLink; }
            set
            {
                SetProperty(ref _videoIntroLink, value);
                RaisePropertyChanged(nameof(VideoIntroLink));
                RaisePropertyChanged(nameof(HasVideoIntro));
            }
        }

        private DateTime _contentRetrieved;
        public DateTime ContentRetrieved
        {
            get { return _contentRetrieved; }
            set
            {
                SetProperty(ref _contentRetrieved, value);
                RaisePropertyChanged(nameof(ContentRetrieved));
            }
        }

        private bool _displayOfflineNotice;
        public bool DisplayOfflineNotice
        {
            get { return _displayOfflineNotice; }
            set
            {
                SetProperty(ref _displayOfflineNotice, value);
                RaisePropertyChanged(nameof(DisplayOfflineNotice));
            }
        }

        private Thickness _videoIntroMargin;
        public Thickness VideoIntroMargin
        {
            get { return _videoIntroMargin; }
            set
            {
                SetProperty(ref _videoIntroMargin, value);
                RaisePropertyChanged(nameof(VideoIntroMargin));
            }
        }

        private string _day;
        public string Day
        {
            get { return _day; }
            set
            {
                SetProperty(ref _day, value);
                RaisePropertyChanged(nameof(Day));
            }
        }

        public bool HasVideoIntro
        {
            get { return !string.IsNullOrWhiteSpace(VideoIntroLink); }
        }

        public ICommand VideoIntro { get; }
        public ICommand ToggleOfflineNotice { get; }

        public SessionDetailsViewModel()
        {
            DisplayOfflineNotice = true;
            VideoIntroMargin = Device.RuntimePlatform == Device.iOS ?
                new Thickness(0, 0, 0, 75) :
                new Thickness(0, 0, 0, 55);
            VideoIntro = new DelegateCommand(OnVideoIntro);
            ToggleOfflineNotice = new DelegateCommand(OnToggleOfflineNotice);
        }

        private void OnToggleOfflineNotice()
        {
            DisplayOfflineNotice = !DisplayOfflineNotice;

            if (DisplayOfflineNotice)
            {
                VideoIntroMargin = Device.RuntimePlatform == Device.iOS ?
                    new Thickness(0, 0, 0, 75) :
                    new Thickness(0, 0, 0, 55);
            }
            else
            {
                VideoIntroMargin = Device.RuntimePlatform == Device.iOS ?
                    new Thickness(0, 0, 0, 30) :
                    new Thickness(0, 0, 0, 10);
            }
        }

        private void OnVideoIntro()
        {
            if (HasVideoIntro)
            {
                Device.OpenUri(new Uri(VideoIntroLink));
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            var isSuccessful = false;

            if (parameters.ContainsKey(nameof(Session)))
            {
                var session = (Session)parameters[nameof(Session)];
                if (session != null)
                {
                    Title = session.Title;
                    Description = session.Description;
                    Speakers = session.Speakers;
                    Room = session.Room;
                    Session = session.TimeSlotName;
                    TimeSlot = session.TimeSlot;
                    SessionTrack = session.Track;
                    VideoIntroLink = session.VideoLink;
                    Day = $"Day {session.Day}";

                    isSuccessful = true;
                }
            }

            if (parameters.ContainsKey(Constants.Navigation.Parameters.LastUpdated))
            {
                ContentRetrieved = (DateTime)parameters[Constants.Navigation.Parameters.LastUpdated];
            }

            if (!isSuccessful)
            {
                // TODO - Add some error page loading sequence
            }
        }
    }
}
