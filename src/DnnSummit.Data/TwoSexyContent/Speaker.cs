using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Speaker : Entity
    {
        [JsonProperty("Photo")]
        public string Photo { get; set; }
    }
}
