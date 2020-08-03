using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper.Models.Base
{
    public class Session
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("connection")]
        public Connection Connection { get; set; }
        [JsonProperty("application")]
        public Application Application { get; set; }
    }
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string ipAddress { get; set; }
    }
    public class Application
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }
}
