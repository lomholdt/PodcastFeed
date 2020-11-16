using System;

namespace PodcastFeed.Domain
{
    public class Item
    {
        public string Id { get; init; } = string.Empty;

        public string Title { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public DateTime? PublishedDate { get; init; }
    }
}
