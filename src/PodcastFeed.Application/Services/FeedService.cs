using PodcastFeed.Domain;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace PodcastFeed.Application.Services
{
    public class FeedService : IFeedService
    {
        private readonly IRssService _rssService;

        public FeedService(IRssService rssService)
        {
            _rssService = rssService;
        }

        public async Task<Feed> GetFeed(string name, int limit, DateTime? publishedDate)
        {
            var channel = await _rssService.GetChannel(name, limit);

            if (channel is null)
            {
                throw new Exception("bla"); // Create proper exception
            }

            channel.Items = channel.Items
                .Where(item => item.PublishedDate >= publishedDate)
                .ToArray();

            var feed = channel.ToDomain();

            return feed;
        }
    }
}
