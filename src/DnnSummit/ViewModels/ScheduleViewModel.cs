using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.ViewModels
{
    public class ScheduleViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        protected IItineraryService ItineraryService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }
        public string Title => "Schedule";
        public ObservableCollection<Day> Days { get; }
        public ScheduleViewModel(
            IItineraryService itineraryService,
            IErrorRetryManager errorRetryManager)
        {
            ItineraryService = itineraryService;
            ErrorRetryManager = errorRetryManager;
            Days = new ObservableCollection<Day>();
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
            }
            catch (Exception)
            {
                await ErrorRetryManager.HandleRetryAsync(this, parameters, attempt);
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            await OnLoadAsync(parameters);
        }
    }
}
