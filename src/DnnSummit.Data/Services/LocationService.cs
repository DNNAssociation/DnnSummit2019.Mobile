using DnnSummit.Data.Extensions;
using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class LocationService : BaseService<TwoSexyContent.Location>, ILocationService
    {
        public LocationService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetLocations")
        {
        }

        public async Task<IEnumerable<Location>> GetAsync()
        {
            var locations = await QueryAsync();
            return locations.Select(x => new Location
            {
                Title = x.Title,
                Description = x.Description,
                HotelName = x.HotelName,
                HotelStandardsTitle = x.HotelStandardsTitle,
                HotelStandard1 = x.HotelStandard1,
                HotelStandard2 = x.HotelStandard2,
                HotelStandard3 = x.HotelStandard3,
                HotelStandard4 = x.HotelStandard4,
                HotelStandard5 = x.HotelStandard5,
                HotelStandard6 = x.HotelStandard6,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                DirectionsFromAirport = x.DirectionsFromAirport,
                ParkingInformation = x.ParkingInformation,
                LocalAttractionsTitle = x.LocalAttractionsTitle,
                LocalAttraction1 = x.LocalAttraction1,
                LocalAttraction2 = x.LocalAttraction2,
                LocalAttraction3 = x.LocalAttraction3,
                LocalAttraction4 = x.LocalAttraction4,
                LocalAttraction5 = x.LocalAttraction5,
                LocalAttraction6 = x.LocalAttraction6,
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
