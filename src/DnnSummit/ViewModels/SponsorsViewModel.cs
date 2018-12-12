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

        private ObservableCollection<Sponsor> _titles;
        public ObservableCollection<Sponsor> Titles
        {
            get { return _titles; }
            set
            {
                SetProperty(ref _titles, value);
                RaisePropertyChanged(nameof(Titles));
                RaisePropertyChanged(nameof(HasTitles));
            }
        }

        private ObservableCollection<Sponsor> _platinums;
        public ObservableCollection<Sponsor> Platinums
        {
            get { return _platinums; }
            set
            {
                SetProperty(ref _platinums, value);
                RaisePropertyChanged(nameof(Platinums));
                RaisePropertyChanged(nameof(HasPlaltinums));
            }
        }

        public ObservableCollection<Sponsor> Golds { get; }
        public ObservableCollection<Sponsor> Silvers { get; }
        public ObservableCollection<Sponsor> Bronzes { get; }

        public bool HasTitles
        {
            get { return Titles.Any(); }
        }

        public bool HasPlaltinums
        {
            get { return Platinums.Any(); }
        }

        public bool HasGolds
        {
            get { return Golds.Any(); }
        }

        public bool HasSilvers
        {
            get { return Silvers.Any(); }
        }

        public bool HasBronzes
        {
            get { return Bronzes.Any(); }
        }

        public SponsorsViewModel(ISponsorService sponsorService)
        {
            SponsorService = sponsorService;
            Titles = new ObservableCollection<Sponsor>();
            Platinums = new ObservableCollection<Sponsor>();
            Golds = new ObservableCollection<Sponsor>();
            Silvers = new ObservableCollection<Sponsor>();
            Bronzes = new ObservableCollection<Sponsor>();

            RaisePropertyChanged(nameof(HasTitles));
            RaisePropertyChanged(nameof(HasPlaltinums));
            RaisePropertyChanged(nameof(HasGolds));
            RaisePropertyChanged(nameof(HasSilvers));
            RaisePropertyChanged(nameof(HasBronzes));
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
            var sponsors = data.Select(x => new Sponsor
            {
                Name = x.Name,
                Homepage = x.Homepage,
                ImageLink = x.ImageLink
            });

            Titles = new ObservableCollection<Sponsor>(data
                .Where(x => x.Level == Data.Models.SponsorLevel.Title)
                .Select(x => new Sponsor
                {
                    Name = x.Name,
                    Homepage = x.Homepage,
                    ImageLink = x.ImageLink
                }));

            Platinums = new ObservableCollection<Sponsor>(data
                .Where(x => x.Level == Data.Models.SponsorLevel.Platinum)
                .Select(x => new Sponsor
                {
                    Name = x.Name,
                    Homepage = x.Homepage,
                    ImageLink = x.ImageLink
                }));

            //ClearData();

            //foreach (var item in data)
            //{
            //    var sponsor = new Sponsor
            //    {
            //        Name = item.Name,
            //        Homepage = item.Homepage,
            //        ImageLink = item.ImageLink
            //    };

            //    switch (item.Level)
            //    {
            //        case Data.Models.SponsorLevel.Title:
            //            Titles.Add(sponsor);
            //            RaisePropertyChanged(nameof(HasTitles));
            //            break;
            //        case Data.Models.SponsorLevel.Platinum:
            //            Platinums.Add(sponsor);
            //            RaisePropertyChanged(nameof(HasPlaltinums));
            //            break;
            //        case Data.Models.SponsorLevel.Gold:
            //            Golds.Add(sponsor);
            //            RaisePropertyChanged(nameof(HasGolds));
            //            break;
            //        case Data.Models.SponsorLevel.Silver:
            //            Silvers.Add(sponsor);
            //            RaisePropertyChanged(nameof(HasSilvers));
            //            break;
            //        case Data.Models.SponsorLevel.Bronze:
            //            Bronzes.Add(sponsor);
            //            RaisePropertyChanged(nameof(HasBronzes));
            //            break;
            //    }
            //}
        }
    }
}
