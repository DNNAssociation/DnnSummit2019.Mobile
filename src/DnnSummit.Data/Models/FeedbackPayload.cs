using Newtonsoft.Json;

namespace DnnSummit.Data.Models
{
    [JsonObject]
    public class FeedbackPayload
    {
        [JsonProperty]
        public int Year { get; set; }

        [JsonProperty]
        public string DeviceId { get; set; }

        [JsonProperty]
        public string SurveyAnswers { get; set; }
    }
}
