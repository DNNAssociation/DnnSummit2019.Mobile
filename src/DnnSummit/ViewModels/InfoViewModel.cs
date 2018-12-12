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
                Title = "Sponsors",
                InfoType = InfoType.Sponsors
            },
            new Tile
            {
                Title = "About",
                InfoType = InfoType.About
            }
        };
    }
}
