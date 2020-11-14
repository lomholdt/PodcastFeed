using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PodcastFeed.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly ILogger<FeedController> _logger;

        public FeedController(ILogger<FeedController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{name}")]
        public async Task<OkObjectResult> Get([FromRoute] string name, [FromQuery] int limit = 10)
        {
            await Task.CompletedTask;
            return Ok(new { name, limit });
        }
    }
}
