using Newtonsoft.Json;
using obilet.Model.Request;

namespace obilet.Model.Session
{
    public class SessionResponse : ResponseBase<SessionInfo>
    {
        public override SessionInfo Data { get; set; }
    }
    public class SessionInfo
    {
        [JsonProperty("session-id")]
        public string sessionId { get; set; }
        [JsonProperty("device-id")]
        public string deviceId { get; set; }
    }
}
