using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PodcastFeed.Application.Services;

namespace PodcastFeed.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly IFeedService _feedService;

        private readonly ILogger<FeedController> _logger;

        public FeedController(ILogger<FeedController> logger, IFeedService feedService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _feedService = feedService ?? throw new ArgumentNullException(nameof(feedService));
        }

        [HttpGet("{name}")]
        public async Task<OkObjectResult> Get([FromRoute] string name, [FromQuery] int limit = 10, [FromQuery] DateTime? publishedDate = default) =>
            Ok(await _feedService.GetFeed(name, limit, publishedDate));

    }
}
