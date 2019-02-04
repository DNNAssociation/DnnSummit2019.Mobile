using System.Collections.Generic;
using System.Windows.Input;
using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class InfoViewModel : BindableBase
    {
        protected INavigationService NavigationService { get; }
        protected IPageDialogService PageDialogService { get; }

        public string Title => "Info";
        public IEnumerable<Tile> Pages => new[]
        {
            new Tile
            {
                Title = "Venue",
                InfoType = InfoType.Venue,
                NavigationPath = Constants.Navigation.VenuePage
            },
            new Tile
            {
                Title = "Sponsors",
                InfoType = InfoType.Sponsors,
                NavigationPath = Constants.Navigation.SponsorsPage
            },
            new Tile
            {
                Title = "Feedback",
                InfoType = InfoType.Feedback,
                NavigationPath = Constants.Navigation.FeedbackPage
            },
            new Tile
            {
                Title = "Credits",
                InfoType = InfoType.Credits,
                NavigationPath = Constants.Navigation.CreditsPage
            },
            new Tile
            {
                Title = "Update Content",
                InfoType = InfoType.Update,
                // this is a quick fix. On iOS we had issues with a white screen appearing
                // when the user did a content update. Navigating back to the root caused issues.
                // We should try and fix this in the future but for now this okay.
                NavigationPath = Device.RuntimePlatform == Device.Android ?
                    $"/{Constants.Navigation.LoadingPage}" :
                    Constants.Navigation.LoadingPage
            },
        };

        public ICommand InfoSelected { get; }

        public InfoViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
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
    }
}
