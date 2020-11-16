using System;

namespace PodcastFeed.Domain
{
    public class Item
    {
        public string Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public DateTime PublishedDate { get; init; }
    }
}
