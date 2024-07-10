using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SparkPost.Sharp.Models
{
    public class TransmissionOptions
    {
        [JsonProperty("click_tracking")]
        [JsonPropertyName("click_tracking")]
        public bool ClickTracking { get; set; } = false;

        [JsonProperty("transactional")]
        [JsonPropertyName("transactional")]
        public bool Transactional { get; set; } = true;

        [JsonProperty("ip_pool")]
        [JsonPropertyName("ip_pool")]
        public string IpPool { get; set; } = "default";

        [JsonProperty("inline_css")]
        [JsonPropertyName("inline_css")]
        public bool InlineCss { get; set; } = true;
    }
}
