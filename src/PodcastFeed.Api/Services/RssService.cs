using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PodcastFeed.Api.Exceptions;
using PodcastFeed.Application.Services;

namespace PodcastFeed.Api.Services
{
    public class RssService : IRssService
    {
        private readonly HttpClient _client;

        public RssService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Channel> GetChannel(string name)
        {
            var uri = $"/mu/feed/{name}";

            var responseStream = await _client.GetStreamAsync(uri);

            XmlSerializer serializer = new XmlSerializer(typeof(Rss));

            try
            {
                var rss = serializer.Deserialize(responseStream) as Rss;
                return rss?.Channel ?? new Channel { };
            }
            catch
            {
                throw new RssNotParsableException();
            }
        }
    }
}
