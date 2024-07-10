using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SparkPost.Sharp.Models
{
    public class TransmissionRecipient
    {
        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        //[JsonProperty("return_path")]
        //[JsonPropertyName("return_path")]
        //public string ReturnPath { get; set; } = string.Empty;

        [JsonProperty("tags")]
        [JsonPropertyName("tags")]
        public string[] Tags { get; set; } = new string[0];

        [JsonProperty("metadata")]
        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; } = new();

        [JsonProperty("substitution_data")]
        [JsonPropertyName("substitution_data")]
        public Dictionary<string, object>? SubstitutionData { get; set; }
    }
}
