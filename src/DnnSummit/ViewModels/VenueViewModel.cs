using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class VenueViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        protected ILocationService LocationService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }

        public string Title => "Location";

        public ObservableCollection<Location> Locations { get; }

        private IEnumerable<Location> _pages;
        public IEnumerable<Location> Pages
        {
            get { return _pages; }
            set
            {
                SetProperty(ref _pages, value);
                RaisePropertyChanged(nameof(Pages));
            }
        }

        public VenueViewModel(
            ILocationService locationService,
            IErrorRetryManager errorRetryManager)
        {
            LocationService = locationService;
            ErrorRetryManager = errorRetryManager;
            Locations = new ObservableCollection<Location>();
            Pages = new ObservableCollection<Location>();
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            await OnLoadAsync(parameters);
        }

        public async Task OnLoadAsync(INavigationParameters parameters, int attempt = 0)
        {
            try
            {
                var data = await LocationService.GetAsync();
                Locations.Clear();
                foreach (var item in data)
                {
                    Locations.Add(new Location
                    {
                        Title = item.Title,
                        Description = item.Description,
                        HotelName = item.HotelName,
                        HotelStandardsTitle = item.HotelStandardsTitle,
                        HotelStandards = item.HotelStandards,
                        Address = item.Address,
                        PhoneNumber = item.PhoneNumber,
                        DirectionsFromAirport = item.DirectionsFromAirport,
                        ParkingInformation = item.ParkingInformation,
                        LocalAttractionsTitle = item.LocalAttractionsTitle,
                        LocalAttractions = item.LocalAttractions,
                        Image = ImageSource.FromStream(() => new MemoryStream(item.Image)),
                        LearnMoreUrl = item.LearnMoreUrl,
                        BookNowUrl = item.BookNowUrl,
                        PhoneNumberUrl = item.PhoneNumberUrl,
                        WebsiteUrl = item.WebsiteUrl,
                        MapUrl = item.MapUrl,
                        WebsiteName = item.WebsiteName
                    });
                }
                Pages = Locations;
            }
            catch (Exception)
            {
                await ErrorRetryManager.HandleRetryAsync(this, parameters, attempt);
            }
        }
    }
}
