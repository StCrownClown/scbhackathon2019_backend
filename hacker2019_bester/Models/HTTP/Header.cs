using Newtonsoft.Json;

namespace hacker2019_bester.Models
{
    public class Header
    {
        public string host { get; set; }
        public string contentType { get; set; }
        public string resourceOwnerId { get; set; }
        public string requestUId { get; set; }
        [JsonProperty(PropertyName = "accept-language")]
        public string acceptLanguage { get; set; }
        public string apikey { get; set; }
        public string apisecret { get; set; }
        [JsonProperty(PropertyName = "response-channel")]
        public string responseChannel { get; set; }
        public string endState { get; set; }
        public string channel { get; set; }
        public string authorization { get; set; }
    }
}
