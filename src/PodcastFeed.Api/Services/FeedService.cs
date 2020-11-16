using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PodcastFeed.Api.Exceptions;

namespace PodcastFeed.Api.Services
{
    public class FeedService : IFeedService
    {
        private readonly HttpClient _client;

        public FeedService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Channel> GetChannel(string name, int limit)
        {
            var uri = $"/mu/feed/{name}?limit={limit}";

            var responseStream = await _client.GetStreamAsync(uri);

            XmlSerializer serializer = new XmlSerializer(typeof(Rss));

            try
            {
                var rssData = serializer.Deserialize(responseStream) as Rss;

                return rssData.Channel;
            }
            catch
            {
                throw new RssNotParsableException();
            }
        }
    }
}
