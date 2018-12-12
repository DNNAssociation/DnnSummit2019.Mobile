using DnnSummit.Models;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class SponsorsViewModel : BindableBase
    {
        public ObservableCollection<Sponsor> Sponsors { get; }

        public SponsorsViewModel()
        {
            Sponsors = new ObservableCollection<Sponsor>();
        }
    }
}
