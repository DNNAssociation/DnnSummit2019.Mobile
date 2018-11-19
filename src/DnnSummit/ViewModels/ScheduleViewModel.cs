using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class ScheduleViewModel : BindableBase
    {
        protected INavigationService NavigationService { get; }
        public string Title => "Scedule";
        public ObservableCollection<Event> Days { get; set; }
        public ICommand DaySelected { get; }

        public ScheduleViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            DaySelected = new DelegateCommand<Event>(OnDaySelected);

            // TODO - populate this from a service or REST call
            Days = new ObservableCollection<Event>(new[]
            {
                new Event
                {
                    Title = "Day 1",
                    Notes = "Training & Business Round Table",
                    Description = "Training & Business Round Table"
                },
                new Event
                {
                    Title = "Day 2-3",
                    Notes = "Conference & After Party",
                    Description = "Conference & After Party"
                },
                new Event
                {
                    Title = "Day 4-5",
                    Notes = "DNN on the slopes",
                    Description = "DNN on the slopes"
                }
            });
        }

        private async void OnDaySelected(Event day)
        {
            var navigationParameters = new NavigationParameters()
            {
                { nameof(Event), day }
            };
            await NavigationService.NavigateAsync(Constants.Navigation.ScheduleDetailsPage, navigationParameters);
        }
    }
}
