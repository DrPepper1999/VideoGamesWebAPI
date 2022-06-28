using Microsoft.EntityFrameworkCore;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IDeveloperStudioDbCotext
    {
         DbSet<DeveloperStudio> DeveloperStudios { get; set; }
         Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
