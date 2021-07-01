using AmazonTracker.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExposeReview.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExposeController : ControllerBase
    {
        private readonly IReviewResultRepository _reviewResultRepository;
        private readonly ILogger<ExposeController> _logger;

        public ExposeController(ILogger<ExposeController> logger, IReviewResultRepository reviewResultRepository)
        {
            _logger = logger;
            _reviewResultRepository = reviewResultRepository;
        }

        [HttpGet]
        [Route("GetReviews")]
        public async Task<IActionResult> GetReviews(string query)
        {
            _logger.LogInformation("Call TrackReview function init", query);
            var result = await _reviewResultRepository.GetItemsAsync(query);
            return Ok(result);
        }
    }
}
