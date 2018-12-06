using Newtonsoft.Json;
using System.Collections.Generic;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class Speaker : Entity
    {
        [JsonProperty("Photo")]
        public string Photo { get; set; }
        
        [JsonProperty("Twitter")]
        public string Twitter { get; set; }

        [JsonProperty("Bio")]
        public string Bio { get; set; }

        [JsonProperty("Sessions")]
        public IEnumerable<Session> Sessions { get; set; }
    }
}
