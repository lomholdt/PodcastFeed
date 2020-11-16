using System;
using System.Threading.Tasks;

namespace PodcastFeed.Api.Services
{
    public interface IFeedService
    {
        public Task<Channel> GetChannel(string name, int limit);
    }
}
