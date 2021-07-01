using Newtonsoft.Json;

namespace AmazonTracker.Domain.Models
{
    public class Asin
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }
    }
}
