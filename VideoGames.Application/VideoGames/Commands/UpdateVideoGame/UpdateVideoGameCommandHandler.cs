using Microsoft.EntityFrameworkCore;
using MediatR;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Application.Common.Exceptions;

namespace VideoGames.Application.VideoGames.Commands.UpdateVideoGame
{
    public class UpdateVideoGameCommandHandler : IRequestHandler<UpdateVideoGameCommand>
    {
        private readonly IVideoGamesDbContext _dbContext;
        public UpdateVideoGameCommandHandler(IVideoGamesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateVideoGameCommand request, CancellationToken cancellationToken)
        {
            var videoGame = await _dbContext.VideoGames
                .FirstOrDefaultAsync(vg => vg.Id == request.Id, cancellationToken);

            if (videoGame == null)
            {
                throw new NotFoundException(nameof(VideoGame), request.Id);
            }

            if (request.DeveloperStudioId.HasValue)
            {
                var developerStudio = await _dbContext.DeveloperStudios
                    .FirstOrDefaultAsync(ds => ds.Id == request.DeveloperStudioId, cancellationToken);

                if (developerStudio == null)
                {
                    throw new NotFoundException(nameof(DeveloperStudio), request.DeveloperStudioId);
                }

                videoGame.DeveloperStudio = developerStudio;
            }

            if (request.GenreIds != null)
            {
                var genres = await _dbContext.VideoGameGenres
                    .Where(genre => request.GenreIds.Contains(genre.Id))
                    .ToListAsync(cancellationToken);

                if (!genres.Any())
                {
                    throw new NotFoundException(nameof(VideoGameGenre), request.GenreIds);
                }

                videoGame.Genres = genres;
            }

            videoGame.Name = request.Name ?? videoGame.Name;
            videoGame.RelesesDate = request.RelesesDate ?? videoGame.RelesesDate;
            videoGame.Rating = request.Rating ?? videoGame.Rating;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
