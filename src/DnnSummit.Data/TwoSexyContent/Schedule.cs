﻿using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Schedule : Entity
    {
        [JsonProperty("BannerTitle")]
        public string BannerTitle { get; set; }

        [JsonProperty("BannerHeading")]
        public string BannerHeading { get; set; }

        [JsonProperty("Heading")]
        public string Heading { get; set; }

        [JsonProperty("MobileAppTitle")]
        public string MobileAppTitle { get; set; }
    }
}