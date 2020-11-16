using System.Threading.Tasks;

namespace PodcastFeed.Application.Services
{
    public interface IRssService
    {
        public Task<Channel?> GetChannel(string name, int limit);
    }
}
