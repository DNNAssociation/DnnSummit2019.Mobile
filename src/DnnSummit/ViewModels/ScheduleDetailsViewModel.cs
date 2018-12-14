using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
                    Heading = details.Banner.Heading;
                    SubHeading = details.Banner.SubHeading;

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
