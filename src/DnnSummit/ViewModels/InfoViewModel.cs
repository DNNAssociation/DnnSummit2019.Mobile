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
                InfoType = InfoType.Feedback
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
                NavigationPath = $"/{Constants.Navigation.LoadingPage}"
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
