using Newtonsoft.Json;

namespace AmazonTracker.Domain.Models
{
    public class StarsStat
    {
        [JsonProperty("_1")]
        public string OneStar { get; set; }

        [JsonProperty("_2")]
        public string TwoStar { get; set; }

        [JsonProperty("_3")]
        public string ThreeStar { get; set; }

        [JsonProperty("_4")]
        public string FourStar { get; set; }

        [JsonProperty("_5")]
        public string FiveStar { get; set; }
    }
}
