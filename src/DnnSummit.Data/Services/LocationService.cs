using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
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
            return locations.Select(x => new Location
            {
                Title = x.Title,
                Description = x.Description,
                HotelName = x.HotelName,
                HotelStandardsTitle = x.HotelStandardsTitle,
                HotelStandards = new[]
                {
                    x.HotelStandard1,
                    x.HotelStandard2,
                    x.HotelStandard3,
                    x.HotelStandard4,
                    x.HotelStandard5,
                    x.HotelStandard6
                },
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                DirectionsFromAirport = x.DirectionsFromAirport,
                ParkingInformation = x.ParkingInformation,
                LocalAttractionsTitle = x.LocalAttractionsTitle,
                LocalAttractions = new[]
                {
                    x.LocalAttraction1,
                    x.LocalAttraction2,
                    x.LocalAttraction3,
                    x.LocalAttraction4,
                    x.LocalAttraction5,
                    x.LocalAttraction6
                },
                Image = $"https://www.dnnsummit.org{x.Image}",
                LearnMoreUrl = x.LearnMoreUrl,
                BookNowUrl = x.BookNowUrl,
                PhoneNumberUrl = x.PhoneNumberUrl,
                WebsiteUrl = x.WebsiteUrl,
                MapUrl = x.MapUrl,
                WebsiteName = x.WebsiteName
            });
        }
    }
}
