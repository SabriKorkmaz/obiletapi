﻿using System;
using Newtonsoft.Json;

namespace obilet.Model.Entity
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
