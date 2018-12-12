using DnnSummit.Models;
using Prism.Mvvm;
using System.Collections.Generic;

namespace DnnSummit.ViewModels
{
    public class InfoViewModel : BindableBase
    {
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
                InfoType = InfoType.Sponsors
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
    }
}
