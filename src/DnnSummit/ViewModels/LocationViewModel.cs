using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class LocationViewModel : BindableBase, INavigatingAware
    {
        protected ILocationService LocationService { get; }

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

        public LocationViewModel(ILocationService locationService)
        {
            LocationService = locationService;
            Locations = new ObservableCollection<Location>();
            Pages = new ObservableCollection<Location>();
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
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
                    Image = item.Image,
                    LearnMoreUrl = item.LearnMoreUrl,
                    BookNowUrl = item.BookNowUrl,
                    PhoneNumberUrl = item.PhoneNumberUrl,
                    WebsiteUrl = item.WebsiteUrl,
                    MapUrl = item.MapUrl,
                    WebsiteName = item.WebsiteName
                });
            }
            Pages = Locations;

            // TODO - pull this from the dnn summit website
            /*Pages = new[]
            {
                new Location
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/banner-denver.jpg",
                    ImageTitle = "DENVER, CO",
                    Title = "Embassy Suites",
                    Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
                },
                new Location
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/embassy-suites.jpg",
                    ImageTitle = "HOTEL & CONFERENCE",
                    Title = "",
                    Description = "DNN Summit will be held at The Embassy Suites by Hilton Denver Downtown Convention Center and Hotel.\r\n\r\nA block of rooms has been reserved for February 17, 2019 - February 24, 2019. The special room rate will be available until January 18th or until the group block is sold-out, whichever comes first. Click Here to Book."
                },
                new Location
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/map-image.jpg",
                    ImageTitle = "GETTING THERE",
                    Title = "Travel",
                    Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
                },
                new Location
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/red-rocks.jpg",
                    ImageTitle = "WHAT TO DO?",
                    Title = "Things to do",
                    Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
                }
            };*/
        }
    }
}
