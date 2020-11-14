using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace PodcastFeed.Api.Services
{
    public class FeedService : IFeedService
    {
        private readonly HttpClient _client;

        public FeedService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Feed> GetFeed(string name, int limit)
        {
            var uri = $"{name}.xml?format=podcast&amp;limit={limit}";

            var responseString = await _client.GetStringAsync(uri);

            var feed = JsonSerializer.Deserialize<Feed>(responseString);

            return feed;
        }
    }

    public record Feed(string Title);
}
