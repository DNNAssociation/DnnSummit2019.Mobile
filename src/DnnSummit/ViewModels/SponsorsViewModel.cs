using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace DnnSummit.ViewModels
{
    public class SponsorsViewModel : BindableBase, INavigatingAware
    {
        protected ISponsorService SponsorService { get; }
        public ObservableCollection<object> Sponsors { get; }

        public SponsorsViewModel(ISponsorService sponsorService)
        {
            SponsorService = sponsorService;
            Sponsors = new ObservableCollection<object>();
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            var data = await SponsorService.GetAsync();
            Sponsors.Clear();

            foreach (var item in data)
            {
                var sponsor = new Sponsor
                {
                    Name = item.Name,
                    Homepage = item.Homepage,
                    ImageLink = item.ImageLink,
                    Level = (SponsorType)item.Level
                };

                switch (item.Level)
                {
                    case Data.Models.SponsorLevel.Title:
                        Sponsors.Add(new TitlePlatinumSponsor
                        {
                            DataContext = sponsor,
                            Level = SponsorType.Title
                        });
                        break;
                    case Data.Models.SponsorLevel.Platinum:
                        Sponsors.Add(new TitlePlatinumSponsor
                        {
                            DataContext = sponsor,
                            Level = SponsorType.Platinum
                        });
                        break;
                }
            }

            var goldGroup = new GeneralSponsor
            {
                DataContext = data
                    .Where(x => x.Level == Data.Models.SponsorLevel.Gold)
                    .Select(x => new Sponsor
                    {
                        Name = x.Name,
                        Homepage = x.Homepage,
                        ImageLink = x.ImageLink,
                        Level = SponsorType.Gold
                    }),
                Level = SponsorType.Gold
            };

            var silverGroup = new GeneralSponsor
            {
                DataContext = data
                    .Where(x => x.Level == Data.Models.SponsorLevel.Silver)
                    .Select(x => new Sponsor
                    {
                        Name = x.Name,
                        Homepage = x.Homepage,
                        ImageLink = x.ImageLink,
                        Level = SponsorType.Silver
                    }),
                Level = SponsorType.Silver
            };

            var bronzeGroup = new GeneralSponsor
            {
                DataContext = data
                    .Where(x => x.Level == Data.Models.SponsorLevel.Bronze)
                    .Select(x => new Sponsor
                    {
                        Name = x.Name,
                        Homepage = x.Homepage,
                        ImageLink = x.ImageLink,
                        Level = SponsorType.Bronze
                    }),
                Level = SponsorType.Bronze
            };

            if(goldGroup.DataContext.Any())
                Sponsors.Add(goldGroup);

            if (silverGroup.DataContext.Any())
                Sponsors.Add(silverGroup);

            if (bronzeGroup.DataContext.Any())
                Sponsors.Add(bronzeGroup);
        }
    }
}
