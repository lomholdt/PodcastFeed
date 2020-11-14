using System.Threading.Tasks;

namespace PodcastFeed.Api.Services
{
    public interface IFeedService
    {
        public Task<Feed> GetFeed(string name, int limit);
    }
}
