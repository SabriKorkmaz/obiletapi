using Newtonsoft.Json;

namespace obilet.Models
{
    public class JourneyModel
    {
        [JsonProperty("originId")]
        public int OriginId { get; set; }
        [JsonProperty("destinationId")]
        public int DestinationId { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}