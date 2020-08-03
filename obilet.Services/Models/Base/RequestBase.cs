using Newtonsoft.Json;
using System;

namespace ApiHelper.Models.Base
{
    public class RequestBase<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        [JsonProperty("date")]
        public DateTime Date => DateTime.Now;
        [JsonProperty("language")]
        public string Language => "tr-TR";
    }
    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
