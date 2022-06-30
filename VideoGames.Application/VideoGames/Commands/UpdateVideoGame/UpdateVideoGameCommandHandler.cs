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
                .Include(db => db.Genres)
                .FirstOrDefaultAsync(vg => vg.Id == request.Id, cancellationToken);

            if (videoGame == null)
            {
                throw new NotFoundException(nameof(VideoGame), request.Id);
            }

            if (request.DeveloperStudioName != null)
            {
                var developerStudio = await _dbContext.DeveloperStudios
                    .FirstOrDefaultAsync(ds => ds.Name == request.DeveloperStudioName,
                    cancellationToken);

                if (developerStudio == null)
                {
                    throw new NotFoundException(nameof(DeveloperStudio), request.DeveloperStudioName);
                }

                videoGame.DeveloperStudio = developerStudio;
            }

            if (IsNotEmpty(request.GenreNames))
            {
                var query = _dbContext.VideoGameGenres.AsQueryable();

                if (IsValidateGenre(request.GenreNames, query))
                {
                    var generError = request.GenreNames
                        .Where(genre => !query.Select(q => q.Name).Contains(genre));
                    throw new GenreDoesNotExist(generError);
                }

                var genres = await query
                    .Where(genre => request.GenreNames.Contains(genre.Name))
                    .ToListAsync(cancellationToken);

                videoGame.Genres = genres;
            }

            videoGame.Name = request.Name ?? videoGame.Name;
            videoGame.ReleaseDate = request.ReleaseDate ?? videoGame.ReleaseDate;
            videoGame.Rating = request.Rating ?? videoGame.Rating;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private static bool IsValidateGenre(IEnumerable<string> genreNames,
            IQueryable<VideoGameGenre> query)
        {
            return !genreNames.All(genre => query.Select(q => q.Name).Contains(genre));
        }

        private static bool IsNotEmpty(IEnumerable<string> genreNames)
        {
            return genreNames != null && genreNames?.Count() != 0;
        }
    }
}
