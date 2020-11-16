using System;
using System.Collections.Generic;

namespace PodcastFeed.Domain
{
    public class Feed
    {
        public string Title { get; init; }

        public string Description { get; init; }

        public Uri Link { get; init; }

        public IEnumerable<string> Category { get; init; } = Array.Empty<string>();

        public IEnumerable<Item> Items { get; init; } = Array.Empty<Item>();
    }
}
