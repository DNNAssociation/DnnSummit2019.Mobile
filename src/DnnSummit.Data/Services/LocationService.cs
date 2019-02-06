using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class LocationService : BaseService<TwoSexyContent.Location, Location>, ILocationService
    {
        public LocationService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetLocations")
        {
        }

        protected override async Task<IEnumerable<Location>> QueryAndMapAsync()
        {
            var locations = await QueryAsync();

            var results = new List<Task<Location>>();
            foreach (var item in locations)
            {
                results.Add(Task.Run(new Func<Task<Location>>(async () => new Location
                {
                    Title = item.Title,
                    Description = item.Description,
                    HotelName = item.HotelName,
                    HotelStandardsTitle = item.HotelStandardsTitle,
                    HotelStandards = new[]
                    {
                        item.HotelStandard1,
                        item.HotelStandard2,
                        item.HotelStandard3,
                        item.HotelStandard4,
                        item.HotelStandard5,
                        item.HotelStandard6
                    },
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber,
                    DirectionsFromAirport = item.DirectionsFromAirport,
                    ParkingInformation = item.ParkingInformation,
                    LocalAttractionsTitle = item.LocalAttractionsTitle,
                    LocalAttractions = new[]
                    {
                        item.LocalAttraction1,
                        item.LocalAttraction2,
                        item.LocalAttraction3,
                        item.LocalAttraction4,
                        item.LocalAttraction5,
                        item.LocalAttraction6
                    },
                    Image = await GetImageFromUrlAsync($"https://www.dnnsummit.org{item.Image}"),
                    IsImageDark = item.IsImageDark,
                    LearnMoreUrl = item.LearnMoreUrl,
                    BookNowUrl = item.BookNowUrl,
                    PhoneNumberUrl = item.PhoneNumberUrl,
                    WebsiteUrl = item.WebsiteUrl,
                    MapUrl = item.MapUrl,
                    WebsiteName = item.WebsiteName
                })));
            }

            return await Task.WhenAll(results);
        }
    }
}
