using Microsoft.EntityFrameworkCore;
using MediatR;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Application.Common.Exceptions;

namespace VideoGames.Application.VideoGames.Commands.CreateVideoGame
{
    public class CreateVideoGameCommandHandler : IRequestHandler<CreateVideoGameCommand, Guid>
    {
        private readonly IVideoGamesDbContext _dbContext;
        public CreateVideoGameCommandHandler(IVideoGamesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateVideoGameCommand request, CancellationToken cancellationToken)
        {
            var developerStudio = await _dbContext.DeveloperStudios
                .FirstOrDefaultAsync(ds => ds.Id == request.DeveloperStudioId, cancellationToken);

            if (developerStudio == null)
            {
                throw new NotFoundException(nameof(DeveloperStudio), request.DeveloperStudioId);
            }

            var genres = await _dbContext.VideoGameGenres
                .Where(genre => request.GenreIds.Contains(genre.Id))
                .ToListAsync(cancellationToken);

            if (!genres.Any())
            {
                throw new NotFoundException(nameof(VideoGameGenre), request.GenreIds);
            }

            var videoGame = new VideoGame
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                RelesesDate = request.ReleaseDate,
                Rating = request.Rating,
                DeveloperStudio = developerStudio,
                Genres = genres
            };

            await _dbContext.VideoGames.AddAsync(videoGame, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return videoGame.Id;
        }
    }
}
