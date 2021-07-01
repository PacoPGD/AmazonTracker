using AmazonTracker.Domain.Models;
using AmazonTracker.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace CollectReview.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectController : ControllerBase
    {
        private readonly IReviewResultRepository _reviewResultRepository;
        private readonly ILogger<CollectController> _logger;

        public CollectController(ILogger<CollectController> logger, IReviewResultRepository reviewResultRepository)
        {
            _logger = logger;
            _reviewResultRepository = reviewResultRepository;
        }

        [HttpPost]
        [Route("TrackReview")]
        public async Task<IActionResult> TrackReview(string asin)
        {
            _logger.LogInformation("Call TrackReview function init", asin);

            var trackReviewsEntity = CallApi(asin);
            var itemAddListTask = trackReviewsEntity.ResultList.Select(r => _reviewResultRepository.AddItemAsync(r)).ToList();
            await Task.WhenAll(itemAddListTask);

            _logger.LogInformation("Call TrackReview function finish");

            return Ok(trackReviewsEntity);
        }

        private TrackReviewsEntity CallApi(string asin)
        {
            var client = new RestClient($"https://amazon23.p.rapidapi.com/reviews?asin=" + asin);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "2f75e0d648mshfb4fa52b82b99a7p1d02fajsn3b30aec15d57");
            request.AddHeader("x-rapidapi-host", "amazon23.p.rapidapi.com");
            var response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<TrackReviewsEntity>(response.Content);

            return result;
        }
    }
}
