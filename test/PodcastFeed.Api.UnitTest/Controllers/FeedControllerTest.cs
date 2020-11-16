using System;
using Xunit;
using PodcastFeed.Api.Controllers;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PodcastFeed.Application.Services;

namespace PodcastFeed.Api.UnitTest
{
    public abstract class FeedControllerTest
    {
        public sealed class When_Creating_Instance : FeedControllerTest
        {
            private readonly ILogger<FeedController> _logger = Substitute.For<ILogger<FeedController>>();

            private readonly IFeedService _feedHandler = Substitute.For<IFeedService>();

            [Fact]
            public void It_throws_when_logger_is_null()
            {
                Assert.Throws<ArgumentNullException>(() => new FeedController(default, _feedHandler));
            }

            [Fact]
            public void It_throws_when_feed_handler_is_null()
            {
                Assert.Throws<ArgumentNullException>(() => new FeedController(_logger, default));
            }
        }
    }
}
