using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Extensions;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class SpeakersViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        protected INavigationService NavigationService { get; }
        protected ISpeakerService SpeakerService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }

        public string Title => "Speakers";

        public ObservableCollection<Speaker> Speakers { get; }
        public ICommand SessionSelected { get; }

        public SpeakersViewModel(
            INavigationService navigationService,
            ISpeakerService speakerService,
            IErrorRetryManager errorRetryManager)
        {
            NavigationService = navigationService;
            SpeakerService = speakerService;
            ErrorRetryManager = errorRetryManager;
            Speakers = new ObservableCollection<Speaker>();
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
        }

        private async void OnSessionSelected(Session session)
        {
            if (session != null)
            {
                var navigationParameter = new NavigationParameters()
                {
                    { nameof(Session), session },
                };
                await NavigationService.NavigateAsync(Constants.Navigation.SessionDetailsPage, navigationParameter);
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            await OnLoadAsync(parameters);
        }

        public async Task OnLoadAsync(INavigationParameters parameters, int attempt = 0)
        {
            try
            {
                var data = await SpeakerService.GetAsync();
                if (data == null) return;

                Speakers.Clear();
                foreach (var item in data)
                {
                    Speakers.Add(new Speaker
                    {
                        Name = item.Name,
                        Bio = item.Bio,
                        Headshot = ImageSource.FromStream(() => new MemoryStream(item.Photo)),
                        Sessions = item.Sessions.Select(x => new Session
                        {
                            Title = x.Title,
                            Description = x.Description,
                            IsFavorite = false,
                            Room = x.Room,
                            TimeSlot = x.TimeSlot,
                            TimeSlotName = x.TimeSlotName,
                            Track = x.Category.ToSessionTrack(),
                            //Speakers = new Speaker
                            //{
                            //    Name = item.Name,
                            //    Headshot = ImageSource.FromStream(() => new MemoryStream(item.Photo))
                            //}
                        })
                    });
                }
            }
            catch (Exception)
            {
                await ErrorRetryManager.HandleRetryAsync(this, parameters, attempt);
            }
        }
    }
}
