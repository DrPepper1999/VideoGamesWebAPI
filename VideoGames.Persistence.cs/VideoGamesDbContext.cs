using Microsoft.EntityFrameworkCore;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Persistence.EntityTypeConfigurations;

namespace VideoGames.Persistence
{
    public class VideoGamesDbContext
        : DbContext, IVideoGameDbContext, IVideoGameGenreDbContext, IDeveloperStudioDbCotext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<VideoGameGenre> VideoGameGenres { get; set; }
        public DbSet<DeveloperStudio> DeveloperStudios { get; set; }

        public VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> options)
        : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VideoGameConfiguration());
            builder.ApplyConfiguration(new VideoGameGenreConfiguration());
            builder.ApplyConfiguration(new DeveloperStudioConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
