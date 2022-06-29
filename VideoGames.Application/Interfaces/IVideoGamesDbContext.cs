using Microsoft.EntityFrameworkCore;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IVideoGamesDbContext
    {
        public DbSet<DeveloperStudio> DeveloperStudios { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<VideoGameGenre> VideoGameGenres { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
