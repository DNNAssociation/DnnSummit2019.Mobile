using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class SessionsViewModel : BindableBase
    {
        protected INavigationService NavigationService { get; }
        public string Title => "Sessions";
        public ObservableCollection<SessionList> Sessions { get; set; }
        
        public ICommand SessionSelected { get; }
        public ICommand SwapState { get; }

        private bool _isViewingFavoriteSessions;
        public bool IsViewingFavoriteSessions
        {
            get { return _isViewingFavoriteSessions; }
            set
            {
                SetProperty(ref _isViewingFavoriteSessions, value);
                RaisePropertyChanged(nameof(IsViewingFavoriteSessions));
            }
        }

        public SessionsViewModel(INavigationService navigationService)
        {
            IsViewingFavoriteSessions = false;
            NavigationService = navigationService;
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
            SwapState = new DelegateCommand(OnSwapState);

            Sessions = new ObservableCollection<SessionList>(new[]
            {
                new SessionList("Session 1", "9:10 - 10:10")
                {                    
                    new Session
                    {
                        Title = "Session Name 1",
                        Room = "Erie",
                        Description = "Description",
                        Track = SessionTrack.Design
                    },
                    new Session
                    {
                        Title = "Session Name 3",
                        Room = "Michigan",
                        Description = "Description",
                        Track = SessionTrack.Development
                    },
                    new Session
                    {
                        Title = "Session Name 2",
                        Room = "Ontario",
                        Description = "Description",
                        Track = SessionTrack.Marketing
                    },
                    new Session
                    {
                        Title = "Session Name 5",
                        Room = "Erie",
                        Description = "Description",
                        Track = SessionTrack.Development
                    },
                    new Session
                    {
                        Title = "Session Name 4",
                        Room = "Superior",
                        Description = "Description",
                        Track = SessionTrack.Design
                    },
                    new Session
                    {
                        Title = "Session Name 6",
                        Room = "Erie",
                        Description = "Description",
                        Track = SessionTrack.Marketing
                    },
                    new Session
                    {
                        Title = "Session Name 7",
                        Room = "Ontario",
                        Description = "Description",
                        Track = SessionTrack.Development
                    }
                },
                new SessionList("Session 2", "10:20 - 11:20")
                {
                    new Session
                    {
                        Title = "Session Name 1",
                        Room = "Erie",
                        Description = "Description",
                        Track = SessionTrack.Design
                    },
                    new Session
                    {
                        Title = "Session Name 3",
                        Room = "Michigan",
                        Description = "Description",
                        Track = SessionTrack.Development
                    },
                    new Session
                    {
                        Title = "Session Name 2",
                        Room = "Ontario",
                        Description = "Description",
                        Track = SessionTrack.Marketing
                    },
                    new Session
                    {
                        Title = "Session Name 5",
                        Room = "Erie",
                        Description = "Description",
                        Track = SessionTrack.Development
                    },
                    new Session
                    {
                        Title = "Session Name 4",
                        Room = "Superior",
                        Description = "Description",
                        Track = SessionTrack.Design
                    },
                    new Session
                    {
                        Title = "Session Name 6",
                        Room = "Erie",
                        Description = "Description",
                        Track = SessionTrack.Marketing
                    },
                    new Session
                    {
                        Title = "Session Name 7",
                        Room = "Ontario",
                        Description = "Description",
                        Track = SessionTrack.Development
                    }
                }
            });
        }

        private async void OnSessionSelected(Session session)
        {
            if (session != null)
            {
                var navigationParameter = new NavigationParameters()
                {
                    { nameof(Session), session }
                };
                await NavigationService.NavigateAsync(Constants.Navigation.SessionDetailsPage, navigationParameter);
            }
        }

        private void OnSwapState()
        {
            IsViewingFavoriteSessions = !IsViewingFavoriteSessions;
        }
    }
}
