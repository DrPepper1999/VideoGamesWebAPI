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
        public async Task<Guid> Handle(CreateVideoGameCommand request,
            CancellationToken cancellationToken)
        {
            var developerStudio = await _dbContext.DeveloperStudios
                .FirstOrDefaultAsync(ds => ds.Name == request.DeveloperStudioName, cancellationToken);

            if (developerStudio == null)
            {
                throw new NotFoundException(nameof(DeveloperStudio), request.DeveloperStudioName);
            }

            var query = _dbContext.VideoGameGenres.AsQueryable();

            if (!request.GenreNames.All(genre => query.Select(q => q.Name).Contains(genre)))
            {
                var generError = request.GenreNames
                    .Where(genre => !query.Select(q => q.Name).Contains(genre));
                throw new GenreDoesNotExist(generError);
            }

            var genres = await query
                .Where(genre => request.GenreNames.Contains(genre.Name))
                .ToListAsync(cancellationToken);

            var videoGame = new VideoGame
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ReleaseDate = request.ReleaseDate,
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
