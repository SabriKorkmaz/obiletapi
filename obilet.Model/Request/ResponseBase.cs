using Newtonsoft.Json;

namespace obilet.Model.Request
{
    public class ResponseBase<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public virtual T Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("user-message")]
        public string UserMessage { get; set; }
        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }
        [JsonProperty("controller")]
        public string Controller { get; set; }
    } 
}
