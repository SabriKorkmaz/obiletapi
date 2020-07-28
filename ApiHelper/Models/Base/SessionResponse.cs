using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models.Base
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
