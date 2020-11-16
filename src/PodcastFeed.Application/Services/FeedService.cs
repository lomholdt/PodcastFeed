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
            _rssService = rssService ?? throw new ArgumentNullException(nameof(rssService));
        }

        public async Task<Feed> GetFeed(string name, int limit, DateTime? publishedDate)
        {
            var channel = await _rssService.GetChannel(name);

            if (publishedDate is not null)
            {
                channel.Items = channel.Items
                    .Where(item => item.PublishedDate >= publishedDate)
                    .ToArray();
            }

            if (limit > 0)
            {
                channel.Items = channel.Items
                    .Take(limit)
                    .ToArray();
            }

            return channel.ToDomain();
        }
    }
}
