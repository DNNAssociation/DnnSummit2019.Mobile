using Newtonsoft.Json;
using System.Collections.Generic;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Location : Entity
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("HotelName")]
        public string HotelName { get; set; }

        [JsonProperty("HotelStandardsTitle")]
        public string HotelStandardsTitle { get; set; }

        [JsonProperty("HotelStandard1")]
        public string HotelStandard1 { get; set; }

        [JsonProperty("HotelStandard2")]
        public string HotelStandard2 { get; set; }

        [JsonProperty("HotelStandard3")]
        public string HotelStandard3 { get; set; }

        [JsonProperty("HotelStandard4")]
        public string HotelStandard4 { get; set; }

        [JsonProperty("HotelStandard5")]
        public string HotelStandard5 { get; set; }

        [JsonProperty("HotelStandard6")]
        public string HotelStandard6 { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("DirectionsFromAirport")]
        public string DirectionsFromAirport { get; set; }

        [JsonProperty("ParkingInformation")]
        public string ParkingInformation { get; set; }

        [JsonProperty("LocalAttractionsTitle")]
        public string LocalAttractionsTitle { get; set; }

        [JsonProperty("LocalAttraction1")]
        public string LocalAttraction1 { get; set; }

        [JsonProperty("LocalAttraction2")]
        public string LocalAttraction2 { get; set; }

        [JsonProperty("LocalAttraction3")]
        public string LocalAttraction3 { get; set; }

        [JsonProperty("LocalAttraction4")]
        public string LocalAttraction4 { get; set; }

        [JsonProperty("LocalAttraction5")]
        public string LocalAttraction5 { get; set; }

        [JsonProperty("LocalAttraction6")]
        public string LocalAttraction6 { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("LearnMoreUrl")]
        public string LearnMoreUrl { get; set; }

        [JsonProperty("BookNowUrl")]
        public string BookNowUrl { get; set; }

        [JsonProperty("PhoneNumberUrl")]
        public string PhoneNumberUrl { get; set; }

        [JsonProperty("WebsiteUrl")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("MapUrl")]
        public string MapUrl { get; set; }

        [JsonProperty("WebsiteName")]
        public string WebsiteName { get; set; }
    }
}
