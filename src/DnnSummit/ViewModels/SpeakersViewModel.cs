using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class SpeakersViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }
        protected ISpeakerService SpeakerService { get; }

        public string Title => "Speakers";

        public ObservableCollection<Speaker> Speakers { get; }
        public ICommand SessionSelected { get; }

        public SpeakersViewModel(
            INavigationService navigationService,
            ISpeakerService speakerService)
        {
            NavigationService = navigationService;
            SpeakerService = speakerService;
            Speakers = new ObservableCollection<Speaker>();
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
        }

        private async void OnSessionSelected(Session session)
        {
            if (session != null)
            {
                var navigationParameter = new NavigationParameters()
                {
                    { nameof(Session), session }
                };
                await NavigationService.NavigateAsync(Constants.Navigation.SessionDetailsPage, navigationParameter);
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            var data = await SpeakerService.GetAsync();
            Speakers.Clear();
            foreach (var item in data)
            {
                Speakers.Add(new Speaker
                {
                    Name = item.Name,
                    Bio = item.Bio,
                    HeadshotImage = item.PhotoLink,
                    Sessions = item.Sessions.Select(x => new Session
                    {
                        Title = x.Title,
                        //Description = x.Description,
                        //IsFavorite = false,
                        //Room = x.Room,
                        //TimeSlot = x.TimeSlot,
                        //TimeSlotName = x.TimeSlotName,
                        //Track = x.Category
                    })
                });
            }
        }
    }
}
