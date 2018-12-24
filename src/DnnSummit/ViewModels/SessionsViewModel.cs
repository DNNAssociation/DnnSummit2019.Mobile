using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Extensions;
using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class SessionsViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }
        protected ISessionService SessionService { get; }
        public string Title => "Sessions";
        
        
        public ICommand SessionSelected { get; }
        public ICommand SwapState { get; }
        public ICommand ToggleAsFavorite { get; }

        public ObservableCollection<SessionList> Sessions { get; }

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

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        public SessionsViewModel(
            INavigationService navigationService,
            ISessionService sessionService)
        {
            IsViewingFavoriteSessions = false;
            IsBusy = false;
            NavigationService = navigationService;
            SessionService = sessionService;
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
            SwapState = new DelegateCommand(OnSwapState);
            ToggleAsFavorite = new DelegateCommand<Session>(OnToggleAsFavorite);
            Sessions = new ObservableCollection<SessionList>();
            
        }

        private void OnToggleAsFavorite(Session session)
        {
            session.IsFavorite = !session.IsFavorite;
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

        private async Task LoadSessions()
        {
            var rawSessions = await SessionService.GetAsync();
            var data = rawSessions
                //.Where(x => x.Day == "Day 1")
                .GroupBy(x => x.TimeSlotName, (key, group) => 
                    new SessionList(key, "9:10 - 10:10", 
                        group.Select(x => new Session
                        {
                            Title = x.Title,
                            Description = x.Description,
                            Room = x.Room,
                            Track = x.Category.ToSessionTrack(),
                            TimeSlotName = x.TimeSlotName,
                            TimeSlot = x.TimeSlot,
                            VideoLink = x.VideoLink,
                            Speaker = new Speaker
                            {
                                Name = x.Speaker.Name,
                                Bio = x.Speaker.Bio,
                                Headshot = ImageSource.FromStream(() => new MemoryStream(x.Speaker.Photo))
                            }
                        })));

            Sessions.Clear();

            foreach (var item in data)
            {
                Sessions.Add(item);
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            IsBusy = true;
            await LoadSessions();
            IsBusy = false;
        }
    }
}
