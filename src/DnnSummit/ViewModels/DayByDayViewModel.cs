using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Extensions;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class DayByDayViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        protected INavigationService NavigationService { get; }
        protected IScheduleService ScheduleService { get; }
        protected IPageDialogService PageDialogService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }
        public string Title => "Day-By-Day";
        public ObservableCollection<Event> Days { get; set; }
        public ICommand DaySelected { get; }        

        public DayByDayViewModel(
            INavigationService navigationService,
            IScheduleService scheduleService,
            IPageDialogService pageDialogService,
            IErrorRetryManager errorRetryManager)
        {
            NavigationService = navigationService;
            ScheduleService = scheduleService;
            PageDialogService = pageDialogService;
            ErrorRetryManager = errorRetryManager;

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

        public async Task OnLoadAsync(INavigationParameters parameters, int attempt = 0)
        {
            try
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
                        Retrieved = item.Retrieved,
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
