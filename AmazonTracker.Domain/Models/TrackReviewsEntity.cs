using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmazonTracker.Domain.Models
{
    public class TrackReviewsEntity
    {
        [JsonProperty("total_reviews")]
        public int TotalReviews { get; set; }

        [JsonProperty("stars_stat")]
        public StarsStat StarsStat { get; set; }

        [JsonProperty("result")]
        public List<ReviewResult> ResultList { get; set; }
    }

}
