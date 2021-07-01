using Newtonsoft.Json;
namespace AmazonTracker.Domain.Models
{
    public class ReviewResult 
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("asin")]
        public Asin Asin { get; set; }

        [JsonProperty("review_data")]
        public string ReviewData { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("review")]
        public string Review { get; set; }

        [JsonProperty("verified_purchase")]
        public bool VerifiedPurchase { get; set; }
    }
}
