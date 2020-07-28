using Newtonsoft.Json;

namespace obilet.Models
{
    public class JourneyModel
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("originId")]
        public int OriginId { get; set; }
        [JsonProperty("destinationId")]
        public int DestinationId { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}