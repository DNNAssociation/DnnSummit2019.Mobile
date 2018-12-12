using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Sponsor : Entity
    {
        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Level")]
        public string Level { get; set; }

        [JsonProperty("Homepage")]
        public string Homepage { get; set; }
    }
}
