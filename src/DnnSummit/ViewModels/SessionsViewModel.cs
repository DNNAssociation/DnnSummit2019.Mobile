using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Extensions;
using DnnSummit.Models;
using DnnSummit.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
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
        public ICommand ToggleAsFavorite { get; }
        public ICommand ToggleOfflineNotice { get; }
        public ICommand ChangeDay { get; }

        public ObservableCollection<SessionList> Sessions { get; }
        
        private bool _isBusy;
        private IEnumerable<Data.Models.Session> _allSessions;
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

        public SessionsViewModel(
            INavigationService navigationService,
            ISessionService sessionService)
        {
            IsBusy = false;
            DisplayOfflineNotice = true;
            SelectedDay = SessionDay.Day1;
            NavigationService = navigationService;
            SessionService = sessionService;
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
            ToggleAsFavorite = new DelegateCommand<Session>(OnToggleAsFavorite);
            ToggleOfflineNotice = new DelegateCommand(OnToggleOfflineNotice);
            ChangeDay = new DelegateCommand<object>(OnChangeDay);
            Sessions = new ObservableCollection<SessionList>();
            
        }

        private async void OnChangeDay(object input)
        {
            var newDay = (SessionDay?)input;
            if (newDay.HasValue)
            {
                SelectedDay = newDay.Value;
                SessionsPage.DayChanged(this, null);
                await LoadSessions(SelectedDay);
            }
        }

        private void OnToggleOfflineNotice()
        {
            DisplayOfflineNotice = !DisplayOfflineNotice;
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
        
        private async Task LoadSessions(SessionDay currentDay)
        {
            if (_allSessions == null)
                _allSessions = await SessionService.GetAsync();

            var todaysSessions = _allSessions
                .Where(x => x.Day == (int)currentDay)
                .GroupBy(x => new { x.TimeSlotName, x.TimeSlot }, (key, group) =>
                    new SessionList(key.TimeSlotName, key.TimeSlot,
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
                        })))
                .OrderBy(x => x.Heading);
            
            Sessions.Clear();

            foreach (var item in todaysSessions)
            {
                Sessions.Add(item);
            }

            ContentRetrieved = _allSessions.FirstOrDefault().Retrieved;
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            IsBusy = true;
            await LoadSessions(SessionDay.Day1);
            IsBusy = false;
        }
    }
}
