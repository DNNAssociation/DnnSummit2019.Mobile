using Newtonsoft.Json;
using System.Collections.Generic;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Schedule : Entity
    {
        [JsonProperty("BannerTitle")]
        public string BannerTitle { get; set; }

        [JsonProperty("BannerHeading")]
        public string BannerHeading { get; set; }

        [JsonProperty("MobileAppTitle")]
        public string MobileAppTitle { get; set; }

        [JsonProperty("Contents")]
        public IEnumerable<Entity> Contents { get; set; }
    }
}
