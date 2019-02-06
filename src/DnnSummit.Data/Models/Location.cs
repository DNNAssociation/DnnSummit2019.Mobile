using System.Collections.Generic;

namespace DnnSummit.Data.Models
{
    public class Location
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string HotelName { get; set; }
        public string HotelStandardsTitle { get; set; }
        public IEnumerable<string> HotelStandards { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string DirectionsFromAirport { get; set; }
        public string ParkingInformation { get; set; }
        public string LocalAttractionsTitle { get; set; }
        public IEnumerable<string> LocalAttractions { get; set; }
        public byte[] Image { get; set; }
        public bool IsImageDark { get; set; }
        public string LearnMoreUrl { get; set; }
        public string BookNowUrl { get; set; }
        public string PhoneNumberUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string MapUrl { get; set; }
        public string WebsiteName { get; set; }
    }
}
