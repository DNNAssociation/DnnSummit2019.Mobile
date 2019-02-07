using Newtonsoft.Json;

namespace DnnSummit.Data.TwoSexyContent
{
    [JsonObject]
    internal class CompleteMessage : Entity
    {
        public string Message { get; set; }
    }
}
