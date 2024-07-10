using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SparkPost.Sharp.Models
{
    public class TransmissionRequest
    {
        //[JsonProperty("options")]
        //[JsonPropertyName("options")]
        //public TransmissionOptions Options { get; set; } = new();

        //[JsonProperty("description")]
        //[JsonPropertyName("description")]
        //public string Description { get; set; } = string.Empty;

        //[JsonProperty("campaign_id")]
        //[JsonPropertyName("campaign_id")]
        //public string CampaignId { get; set; } = string.Empty;

        [JsonProperty("metadata")]
        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; } = new();

        //[JsonProperty("substitution_data")]
        //[JsonPropertyName("substitution_data")]
        //public Dictionary<string, object> SubstitutionData { get; set; } = new();

        //[JsonProperty("return_path")]
        //[JsonPropertyName("return_path")]
        //public string ReturnPath { get; set; } = string.Empty;

        [JsonProperty("recipients")]
        [JsonPropertyName("recipients")]
        public List<TransmissionRecipient> Recipients { get; set; } = new List<TransmissionRecipient>();

        [JsonProperty("content")]
        [JsonPropertyName("content")]
        public TransmissionContent Content { get; set; } = new();
    }
}
