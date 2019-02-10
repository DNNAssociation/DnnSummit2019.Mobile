using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using DnnSummit.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class InfoViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }
        protected IPageDialogService PageDialogService { get; }
        protected IFeedbackEndpointService FeedbackEndpointService { get; }

        public string Title => "Info";
        public ObservableCollection<Tile> Pages { get; }

        public ICommand InfoSelected { get; }

        public InfoViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService,
            IFeedbackEndpointService feedbackEndpointService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
            FeedbackEndpointService = feedbackEndpointService;
            Pages = new ObservableCollection<Tile>();
            InfoSelected = new DelegateCommand<Tile>(OnInfoSelected);
        }

        private async void OnInfoSelected(Tile tile)
        {
            if (tile != null && !string.IsNullOrEmpty(tile.NavigationPath))
            {
                if (tile.NavigationPath.Contains(Constants.Navigation.LoadingPage) && Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await PageDialogService.DisplayAlertAsync("No Internet", "Unable to download content, reconnect and try again.", "OK");
                }
                else
                { 
                    await NavigationService.NavigateAsync(tile.NavigationPath);     
                }
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            var feedbackEndpoints = await FeedbackEndpointService.GetAsync();

            Pages.Clear();
            Pages.Add(new Tile
            {
                Title = "Venue",
                InfoType = InfoType.Venue,
                NavigationPath = Constants.Navigation.VenuePage
            });

            Pages.Add(new Tile
            {
                Title = "Sponsors",
                InfoType = InfoType.Sponsors,
                NavigationPath = Constants.Navigation.SponsorsPage
            });

            if (feedbackEndpoints != null && feedbackEndpoints.Any())
            {
                Pages.Add(new Tile
                {
                    Title = "Feedback",
                    InfoType = InfoType.Feedback,
                    NavigationPath = Constants.Navigation.FeedbackPage
                });
            }

            Pages.Add(new Tile
            {
                Title = "Credits",
                InfoType = InfoType.Credits,
                NavigationPath = Constants.Navigation.CreditsPage
            });

            Pages.Add(new Tile
            {
                Title = "Update Content",
                InfoType = InfoType.Update,
                NavigationPath = $"/{Constants.Navigation.LoadingPage}"
            });
        }
    }
}
