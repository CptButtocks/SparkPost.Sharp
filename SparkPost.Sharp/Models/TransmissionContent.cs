using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SparkPost.Sharp.Models
{
    public class TransmissionContent
    {
        [JsonProperty("from")]
        [JsonPropertyName("from")]
        public TransmissionContentFrom From { get; set; } = new TransmissionContentFrom();

        [JsonProperty("subject")]
        [JsonPropertyName("subject")]
        public string Subject { get; set; } = string.Empty;

        [JsonProperty("html")]
        [JsonPropertyName("html")]
        public string Html { get; set; } = string.Empty;

        [JsonProperty("reply_to")]
        [JsonPropertyName("reply_to")]
        public string ReplyTo { get; set; } = string.Empty;

        [JsonProperty("headers")]
        [JsonPropertyName("headers")]
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    }

    public class TransmissionContentFrom
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}
