using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Section : Entity
    {
        [JsonProperty("SubTitle")]
        public string SubTitle { get; set; }

        [JsonProperty("SubTitleNormal")]
        public string SubTitleNormal { get; set; }

        [JsonProperty("IsBigTitle")]
        public bool IsBigTitle { get; set; }

        [JsonProperty("Content")]
        public string Content { get; set; }

        [JsonProperty("ButtonText")]
        public string ButtonText { get; set; }

        [JsonProperty("ButtonLink")]
        public string ButtonLink { get; set; }

        [JsonProperty("YouTubeLink")]
        public string YouTubeLink { get; set; }
    }
}
