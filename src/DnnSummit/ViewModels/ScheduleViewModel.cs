using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Events;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class ScheduleViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        protected IItineraryService ItineraryService { get; }
        protected ISettingsService SettingsService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }
        protected IEventAggregator EventAggregator { get; }
        public string Title => "Schedule";
        public ObservableCollection<Day> Days { get; }
        public ICommand ToggleOfflineNotice { get; }
        public ScheduleViewModel(
            IItineraryService itineraryService,
            ISettingsService settingsService,
            IErrorRetryManager errorRetryManager,
            IEventAggregator eventAggregator)
        {
            ItineraryService = itineraryService;
            SettingsService = settingsService;
            ErrorRetryManager = errorRetryManager;
            EventAggregator = eventAggregator;
            Days = new ObservableCollection<Day>();
            DisplayOfflineNotice = true;
            ToggleOfflineNotice = new DelegateCommand(OnToggleOfflineNotice);
            NoticeMargin = Device.iOS == Device.RuntimePlatform ?
                new Thickness(0, 0, 0, 60) :
                new Thickness(0, 0, 0, 25);
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

        private Thickness _noticeMargin;
        public Thickness NoticeMargin
        {
            get { return _noticeMargin; }
            set
            {
                SetProperty(ref _noticeMargin, value);
                RaisePropertyChanged(nameof(NoticeMargin));
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

        private void UpdateNoticeMargin()
        {
            if (DisplayOfflineNotice)
            {
                NoticeMargin = Device.iOS == Device.RuntimePlatform ?
                    new Thickness(0, 0, 0, 60) :
                    new Thickness(0, 0, 0, 25);
            }
            else
            {
                NoticeMargin = Device.iOS == Device.RuntimePlatform ?
                    new Thickness(0, 0, 0, 10) :
                    new Thickness(0);
            }
        }

        private void OnToggleOfflineNotice()
        {
            DisplayOfflineNotice = !DisplayOfflineNotice;
            App.DisplayOfflineNotice = DisplayOfflineNotice;
            EventAggregator.GetEvent<DisplayNoticeChanged>().Publish(App.DisplayOfflineNotice);
            UpdateNoticeMargin();
        }

        public async Task OnLoadAsync(INavigationParameters parameters, int attempt = 0)
        {
            try
            {
                var data = await ItineraryService.GetAsync();
                Days.Clear();

                foreach (var item in data)
                {
                    Days.Add(new Day
                    {
                        Title = item.Title,
                        Messages = item.Messages.Select(x => new DayMessage
                        {
                            Title = x.Title,
                            Heading = x.Heading,
                            SubHeading = x.SubHeading,
                            Events = x.Events.Select(e => new DayEvent
                            {
                                Title = e.Title,
                                TimeSlot = e.TimeSlot,
                                Description = e.Description,
                                Room = e.Room
                            })
                        })
                    });
                }

                ContentRetrieved = SettingsService.Get().LastUpdated;
            }
            catch (Exception)
            {
                await ErrorRetryManager.HandleRetryAsync(this, parameters, attempt);
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            DisplayOfflineNotice = App.DisplayOfflineNotice;
            UpdateNoticeMargin();
            await OnLoadAsync(parameters);

#if APPCENTER
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(Constants.AppCenter.Events.Schedule);
#endif
        }
    }
}
