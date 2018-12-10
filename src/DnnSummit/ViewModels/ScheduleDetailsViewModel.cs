using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class ScheduleDetailsViewModel : BindableBase, INavigatingAware
    {
        protected IScheduleService ScheduleService { get; }

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

        public ObservableCollection<ScheduleContent> ContentSections { get; set; }

        public ScheduleDetailsViewModel(IScheduleService scheduleService)
        {
            ScheduleService = scheduleService;
            ContentSections = new ObservableCollection<ScheduleContent>();
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            bool isSuccessful = false;
            if (parameters.ContainsKey(nameof(Event)))
            {
                var details = (Event)parameters[nameof(Event)];
                if (details != null)
                {
                    Title = details.Title;
                    Description = details.Description;

                    var data = await ScheduleService.GetAsync("day 1");
                    Heading = data.BannerTitle;
                    SubHeading = data.BannerHeading;

                    ContentSections.Clear();
                    foreach (var item in data.Sections)
                    {
                        ContentSections.Add(new ScheduleContent
                        {
                            Title = item.Title,
                            Heading = item.Heading,
                            Description = item.Description
                        });
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
