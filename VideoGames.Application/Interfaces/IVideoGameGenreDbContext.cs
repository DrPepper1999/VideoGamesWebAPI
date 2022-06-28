using Microsoft.EntityFrameworkCore;
using VideoGames.Domain;


namespace VideoGames.Application.Interfaces
{
    public interface IVideoGameGenreDbContext
    {
         DbSet<VideoGameGenre> VideoGameGenres { get; set; }
         Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
