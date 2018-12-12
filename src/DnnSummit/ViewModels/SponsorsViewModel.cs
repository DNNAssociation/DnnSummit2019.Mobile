using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class SponsorsViewModel : BindableBase, INavigatingAware
    {
        protected ISponsorService SponsorService { get; }
        public ObservableCollection<Sponsor> Titles { get; }
        public ObservableCollection<Sponsor> Platinums { get; }
        public ObservableCollection<Sponsor> Golds { get; }
        public ObservableCollection<Sponsor> Silvers { get; }
        public ObservableCollection<Sponsor> Bronzes { get; }

        public SponsorsViewModel(ISponsorService sponsorService)
        {
            SponsorService = sponsorService;
            Titles = new ObservableCollection<Sponsor>();
            Platinums = new ObservableCollection<Sponsor>();
            Golds = new ObservableCollection<Sponsor>();
            Silvers = new ObservableCollection<Sponsor>();
            Bronzes = new ObservableCollection<Sponsor>();
        }

        private void ClearData()
        {
            Titles.Clear();
            Platinums.Clear();
            Golds.Clear();
            Silvers.Clear();
            Bronzes.Clear();
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            var data = await SponsorService.GetAsync();
            ClearData();

            foreach (var item in data)
            {
                var sponsor = new Sponsor
                {
                    Name = item.Name,
                    Homepage = item.Homepage,
                    ImageLink = item.ImageLink
                };

                switch (item.Level)
                {
                    case Data.Models.SponsorLevel.Title:
                        Titles.Add(sponsor);
                        break;
                    case Data.Models.SponsorLevel.Platinum:
                        Platinums.Add(sponsor);
                        break;
                    case Data.Models.SponsorLevel.Gold:
                        Golds.Add(sponsor);
                        break;
                    case Data.Models.SponsorLevel.Silver:
                        Silvers.Add(sponsor);
                        break;
                    case Data.Models.SponsorLevel.Bronze:
                        Bronzes.Add(sponsor);
                        break;
                }
            }
        }
    }
}
