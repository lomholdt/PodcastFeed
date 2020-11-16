using PodcastFeed.Application.Commands;
using System.Threading.Tasks;

namespace PodcastFeed.Application.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        Task Handle(TCommand command);
    }
}
