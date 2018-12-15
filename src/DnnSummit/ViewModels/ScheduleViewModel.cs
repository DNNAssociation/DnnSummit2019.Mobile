using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DnnSummit.Extensions;
using System.Linq;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class ScheduleViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }
        protected IScheduleService ScheduleService { get; }
        public string Title => "Schedule";
        public ObservableCollection<Event> Days { get; set; }
        public ICommand DaySelected { get; }        

        public ScheduleViewModel(
            INavigationService navigationService,
            IScheduleService scheduleService)
        {
            NavigationService = navigationService;
            ScheduleService = scheduleService;

            DaySelected = new DelegateCommand<Event>(OnDaySelected);
            Days = new ObservableCollection<Event>();
        }

        private async void OnDaySelected(Event day)
        {
            if (day != null)
            {
                var navigationParameters = new NavigationParameters()
                {
                    { nameof(Event), day }
                };
                await NavigationService.NavigateAsync(Constants.Navigation.ScheduleDetailsPage, navigationParameters);
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            var days = await ScheduleService.GetAsync();

            Days.Clear();
            foreach (var item in days)
            {
                Days.Add(new Event
                {
                    Title = item.Title,
                    Notes = item.CardDescription,
                    Description = item.CardDescription,
                    Avatar = item.Title.ToScheduleType(),
                    Banner = (item.BannerTitle, item.BannerHeading, item.BannerImage),
                    ContentSections = item.Sections.Select(x => new ScheduleContent
                    {
                        Title = x.Title,
                        SubTitle = x.SubTitle,
                        SubTitleNormal = x.SubTitleNormal,
                        Heading = x.Heading,
                        Description = x.Description,
                        VideoLink = x.VideoLink,
                        VideoButtonTitle = x.VideoButtonTitle
                    })
                });
            }
        }
    }
}
