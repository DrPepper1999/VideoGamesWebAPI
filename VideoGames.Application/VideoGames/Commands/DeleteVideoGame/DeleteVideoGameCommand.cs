using MediatR;

namespace VideoGames.Application.VideoGames.Commands.DeleteVideoGame
{
    public class DeleteVideoGameCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
