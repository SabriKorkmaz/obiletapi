using Newtonsoft.Json;
using System;

namespace ApiHelper.Models
{
    public class Journeys
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }
        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }
        [JsonProperty("departure-date")]
        public DateTime Date { get; set; }
    }
}
