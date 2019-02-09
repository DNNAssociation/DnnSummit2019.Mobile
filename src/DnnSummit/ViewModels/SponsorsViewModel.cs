using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class SponsorsViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        protected ISponsorService SponsorService { get; }
        protected IPageDialogService PageDialogService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }
        public ObservableCollection<object> Sponsors { get; }
        public ICommand ItemSelected { get; }

        public SponsorsViewModel(
            ISponsorService sponsorService,
            IPageDialogService pageDialogService,
            IErrorRetryManager errorRetryManager)
        {
            SponsorService = sponsorService;
            PageDialogService = pageDialogService;
            ErrorRetryManager = errorRetryManager;
            Sponsors = new ObservableCollection<object>();
            ItemSelected = new DelegateCommand<object>(OnItemSelected);
        }

        private void OnItemSelected(object item)
        {
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            await OnLoadAsync(parameters);
        }

        public async Task OnLoadAsync(INavigationParameters parameters, int attempt = 0)
        {
            try
            {
                var data = await SponsorService.GetAsync();
                Sponsors.Clear();

                foreach (var item in data.OrderBy(x => x.Level))
                {
                    var sponsor = new Sponsor
                    {
                        Name = item.Name,
                        Homepage = item.Homepage,
                        Image = ImageSource.FromStream(() => new MemoryStream(item.Image)),
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
                            Image = ImageSource.FromStream(() => new MemoryStream(x.Image)),
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
                            Image = ImageSource.FromStream(() => new MemoryStream(x.Image)),
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
                            Image = ImageSource.FromStream(() => new MemoryStream(x.Image)),
                            Level = SponsorType.Bronze
                        }),
                    Level = SponsorType.Bronze
                };

                if (goldGroup.DataContext.Any())
                    Sponsors.Add(goldGroup);

                if (silverGroup.DataContext.Any())
                    Sponsors.Add(silverGroup);

                if (bronzeGroup.DataContext.Any())
                    Sponsors.Add(bronzeGroup);
            }
            catch (Exception)
            {
                await ErrorRetryManager.HandleRetryAsync(this, parameters, attempt);
            }
        }
    }
}
