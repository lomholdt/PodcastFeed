using System;

namespace PodcastFeed.Application.Commands
{
    public record GetFeedCommand(string Name, int Limit, DateTime? PublishedDate) : Command;
}
