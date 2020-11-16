using PodcastFeed.Domain;
using System;
using System.Threading.Tasks;

namespace PodcastFeed.Application.Services
{
    public interface IFeedService
    {
        Task<Feed> GetFeed(string name, int limit, DateTime? publishedDate);
    }
}
