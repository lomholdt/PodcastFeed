using System;
using Xunit;
using PodcastFeed.Api.Controllers;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PodcastFeed.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PodcastFeed.Api.UnitTest
{
    public abstract class FeedControllerTest
    {
        private readonly ILogger<FeedController> _logger = Substitute.For<ILogger<FeedController>>();

        private readonly IFeedService _feedService = Substitute.For<IFeedService>();

        private readonly FeedController _sut;

        public FeedControllerTest()
        {
            _sut = new FeedController(_logger, _feedService);
        }

        public sealed class When_Creating_Instance : FeedControllerTest
        {
            [Fact]
            public void It_throws_when_logger_is_null()
            {
                Assert.Throws<ArgumentNullException>(() => new FeedController(default, _feedService));
            }

            [Fact]
            public void It_throws_when_feed_service_is_null()
            {
                Assert.Throws<ArgumentNullException>(() => new FeedController(_logger, default));
            }
        }

        public sealed class When_Invoking_Get : FeedControllerTest
        {
            private readonly string _name = "SomeName";
            private readonly int _limit = 42;
            private readonly DateTime _publishedDate = new DateTime(1988, 09, 21);

            [Fact]
            public async Task It_invokes_GetFeed()
            {
                await _sut.Get(_name, _limit, _publishedDate);
                await _feedService.Received().GetFeed(_name, _limit, _publishedDate);
            }

            [Fact]
            public async Task It_returns_the_correct_type()
            {
                var result = await _sut.Get(_name, _limit, _publishedDate);
                Assert.IsType<OkObjectResult>(result);
            }
        }
    }
}
