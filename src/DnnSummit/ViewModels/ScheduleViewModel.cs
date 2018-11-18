using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class ScheduleViewModel : BindableBase
    {
        public string Title => "Scedule";
        public ObservableCollection<Event> Days { get; set; }
        public ICommand DaySelected { get; }

        public ScheduleViewModel()
        {
            DaySelected = new DelegateCommand<Event>(OnDaySelected);
            Days = new ObservableCollection<Event>(new[]
            {
                new Event
                {
                    Title = "Day 1",
                    Description = "Training & Business Round Table"
                },
                new Event
                {
                    Title = "Day 2-3",
                    Description = "Conference & After Party"
                },
                new Event
                {
                    Title = "Day 4-5",
                    Description = "DNN on the slopes"
                }
            });
        }

        private void OnDaySelected(Event day)
        {
        }
    }
}
