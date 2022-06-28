using Microsoft.EntityFrameworkCore;
using VideoGames.Domain;


namespace VideoGames.Application.Interfaces
{
    public interface IVideoGameDbContext
    {
         DbSet<VideoGame> VideoGames { get; set; }
         Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
