using Microsoft.EntityFrameworkCore;
using MediatR;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Application.Common.Exceptions;

namespace VideoGames.Application.VideoGames.Commands.DeleteVideoGame
{
    public class DeleteVideoGameCommandHandler : IRequestHandler<DeleteVideoGameCommand>
    {
        private readonly IVideoGamesDbContext _dbContext;
        public DeleteVideoGameCommandHandler(IVideoGamesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteVideoGameCommand request,
            CancellationToken cancellationToken)
        {
            var videoGame = await _dbContext.VideoGames
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (videoGame == null)
            {
                throw new NotFoundException(nameof(VideoGame), request.Id);
            }

            _dbContext.VideoGames.Remove(videoGame);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
