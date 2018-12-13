using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class InfoViewModel : BindableBase
    {
        protected INavigationService NavigationService { get; }

        public string Title => "Info";
        public IEnumerable<Tile> Pages => new[]
        {
            new Tile
            {
                Title = "Notifications",
                InfoType = InfoType.Notifications
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
                InfoType = InfoType.Credits
            }
        };

        public ICommand InfoSelected { get; }

        public InfoViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            InfoSelected = new DelegateCommand<Tile>(OnInfoSelected);
        }

        private async void OnInfoSelected(Tile tile)
        {
            if (tile != null && !string.IsNullOrEmpty(tile.NavigationPath))
            {
                await NavigationService.NavigateAsync(tile.NavigationPath);
            }
        }
    }
}
