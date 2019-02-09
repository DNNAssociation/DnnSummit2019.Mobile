using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Events;
using DnnSummit.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class ScheduleDetailsViewModel : BindableBase, INavigatingAware
    {
        protected IPageDialogService PageDialogService { get; }
        protected ISettingsService SettingsService { get; }
        protected IEventAggregator EventAggregator { get; }

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

        private string _heading;
        public string Heading
        {
            get { return _heading; }
            set
            {
                SetProperty(ref _heading, value);
                RaisePropertyChanged(nameof(Heading));
            }
        }

        private string _subHeading;
        public string SubHeading
        {
            get { return _subHeading; }
            set
            {
                SetProperty(ref _subHeading, value);
                RaisePropertyChanged(nameof(SubHeading));
            }
        }

        private ImageSource _image;
        public ImageSource Image
        {
            get { return _image; }
            set
            {
                SetProperty(ref _image, value);
                RaisePropertyChanged(nameof(Image));
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

        public ICommand VideoSelected { get; }
        public ICommand ToggleOfflineNotice { get; }

        public ObservableCollection<ScheduleContent> ContentSections { get; set; }

        public ScheduleDetailsViewModel(
            IPageDialogService pageDialogService,
            ISettingsService settingsService,
            IEventAggregator eventAggregator)
        {
            PageDialogService = pageDialogService;
            SettingsService = settingsService;
            EventAggregator = eventAggregator;
            DisplayOfflineNotice = true;
            ContentSections = new ObservableCollection<ScheduleContent>();
            VideoSelected = new DelegateCommand<string>(OnVideoSelected);
            ToggleOfflineNotice = new DelegateCommand(OnToggleOfflineNotice);
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

        private async void OnVideoSelected(string link)
        {
            if (string.IsNullOrEmpty(link)) return;

            try
            {
                Device.OpenUri(new Uri(link));
            }
            catch (Exception)
            {
                await PageDialogService.DisplayAlertAsync("Something went wrong", "Unable to open video", "OK");
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            bool isSuccessful = false;
            DisplayOfflineNotice = App.DisplayOfflineNotice;
            UpdateNoticeMargin();
            if (parameters.ContainsKey(nameof(Event)))
            {
                var details = (Event)parameters[nameof(Event)];
                if (details != null)
                {
                    Title = details.Title;
                    Description = details.Description;
                    Heading = details.Banner.Heading;
                    SubHeading = details.Banner.SubHeading;
                    Image = ImageSource.FromStream(() => new MemoryStream(details.Banner.Image));
                    ContentRetrieved = SettingsService.Get().LastUpdated;

                    ContentSections.Clear();
                    foreach (var item in details.ContentSections)
                    {
                        ContentSections.Add(item);
                    }

                    isSuccessful = true;
                }
            }

            if (!isSuccessful)
            {
                // display error page
            }
        }
    }
}
