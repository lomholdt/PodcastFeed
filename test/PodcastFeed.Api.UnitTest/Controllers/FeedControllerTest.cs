using System;
using Xunit;
using PodcastFeed.Api.Controllers;
namespace PodcastFeed.Api.UnitTest
{
    public abstract class FeedControllerTest
    {
        public sealed class When_Creating_Instance : FeedControllerTest
        {
            [Fact]
            public void It_throws_when_logger_is_null()
            {
                Assert.Throws<ArgumentNullException>(() => new FeedController(default));
            }
        }
    }
}
