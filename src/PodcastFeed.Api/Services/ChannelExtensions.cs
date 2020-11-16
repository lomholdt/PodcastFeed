using System;
using System.Linq;
using PodcastFeed.Domain;

namespace PodcastFeed.Api.Services
{
    public static class ChannelExtensions
    {
        public static Feed ToDomain(this Channel self) => new Feed
            {
                Title = self.Title,
                Description = self.Description,
                Category = self.Category,
                Link = new Uri(self.Link),
                Items = self.Items.Select(item => new Domain.Item
                {
                    Id = item.Guid,
                    Description = item.Description,
                    Title = item.Title,
                    PublishedDate = DateTime.Parse(item.PubDate)
                }),
            };
    }
}
