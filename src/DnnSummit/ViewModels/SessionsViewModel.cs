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
        public ICommand ToggleOfflineNotice { get; }
        public ICommand ChangeDay { get; }

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

        private SessionDay _selectedDay;
        public SessionDay SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                SetProperty(ref _selectedDay, value);
                RaisePropertyChanged(nameof(SelectedDay));
            }
        }

        public SessionDay Day1 => SessionDay.Day1;
        public SessionDay Day2 => SessionDay.Day2;

        private Thickness _floatingButtonMargin;
        public Thickness FloatingButtonMargin
        {
            get { return _floatingButtonMargin; }
            set
            {
                SetProperty(ref _floatingButtonMargin, value);
                RaisePropertyChanged(nameof(FloatingButtonMargin));
            }
        }

        public SessionsViewModel(
            INavigationService navigationService,
            ISessionService sessionService)
        {
            IsViewingFavoriteSessions = false;
            IsBusy = false;
            DisplayOfflineNotice = true;
            FloatingButtonMargin = new Thickness(0, 0, 10, 45);
            SelectedDay = SessionDay.Day1;
            NavigationService = navigationService;
            SessionService = sessionService;
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
            SwapState = new DelegateCommand(OnSwapState);
            ToggleAsFavorite = new DelegateCommand<Session>(OnToggleAsFavorite);
            ToggleOfflineNotice = new DelegateCommand(OnToggleOfflineNotice);
            ChangeDay = new DelegateCommand<object>(OnChangeDay);
            Sessions = new ObservableCollection<SessionList>();
            
        }

        private void OnChangeDay(object input)
        {
            var newDay = (SessionDay?)input;
            if (newDay.HasValue)
            {
                SelectedDay = newDay.Value;
            }
        }

        private void OnToggleOfflineNotice()
        {
            DisplayOfflineNotice = !DisplayOfflineNotice;

            if (DisplayOfflineNotice)
            {
                FloatingButtonMargin = new Thickness(0, 0, 10, 45);
            }
            else
            {
                FloatingButtonMargin = new Thickness(0, 0, 10, 10);
            }
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
                            Retrieved = x.Retrieved,
                            Speakers = x.Speakers.Select(s => new Speaker
                            {
                                Name = s.Name,
                                Bio = s.Bio,
                                Headshot = ImageSource.FromStream(() => new MemoryStream(s.Photo))
                            })
                        })));

            Sessions.Clear();

            foreach (var item in data)
            {
                Sessions.Add(item);
            }

            ContentRetrieved = rawSessions.FirstOrDefault().Retrieved;
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            IsBusy = true;
            await LoadSessions();
            IsBusy = false;
        }
    }
}
