using Newtonsoft.Json;

namespace AmazonTracker.Domain.Models
{
    public class Date
    {
        [JsonProperty("date")]
        public string StringDate { get; set; }

        [JsonProperty("unix")]
        public int Unix { get; set; }
    }
}
