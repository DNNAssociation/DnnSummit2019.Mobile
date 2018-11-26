using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class SessionsViewModel : BindableBase
    {
        protected INavigationService NavigationService { get; }
        public string Title => "Sessions";
        public ObservableCollection<Session> Sessions { get; set; }
        public ICommand SessionSelected { get; }

        public SessionsViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
            Sessions = new ObservableCollection<Session>(new[]
            {
                new Session
                {
                    Title = "Session Name 1",
                    Room = "Erie",
                    Description = "Description",
                    Track = SessionTrack.Development
                },
                new Session
                {
                    Title = "Session Name 3",
                    Room = "Michigan",
                    Description = "Description",
                    Track = SessionTrack.Development
                },
                new Session
                {
                    Title = "Session Name 2",
                    Room = "Ontario",
                    Description = "Description",
                    Track = SessionTrack.Development
                },
                new Session
                {
                    Title = "Session Name 5",
                    Room = "Erie",
                    Description = "Description",
                    Track = SessionTrack.Development
                },
                new Session
                {
                    Title = "Session Name 4",
                    Room = "Superior",
                    Description = "Description",
                    Track = SessionTrack.Development
                },
                new Session
                {
                    Title = "Session Name 6",
                    Room = "Erie",
                    Description = "Description",
                    Track = SessionTrack.Development
                },
                new Session
                {
                    Title = "Session Name 7",
                    Room = "Ontario",
                    Description = "Description",
                    Track = SessionTrack.Development
                }
            });
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
    }
}
