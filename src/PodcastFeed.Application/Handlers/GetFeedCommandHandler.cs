using PodcastFeed.Application.Commands;
using PodcastFeed.Domain;
using System;
using System.Threading.Tasks;

namespace PodcastFeed.Application.Handlers
{
    public class GetFeedCommandHandler : ICommandHandler<GetFeedCommand>
    {
        public GetFeedCommandHandler()
        {
        }

        public async Task Handle(GetFeedCommand command)
        {
            await Task.CompletedTask;
        }
    }
}
