using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Domain;

namespace VideoGames.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(VideoGamesDbContext context)
        {
            context.Database.EnsureCreated();
        }

        public static async Task InitializeAsync(VideoGamesDbContext dbContext,
            CancellationToken cancellationToken = default)
        {
            if (await dbContext.Database.EnsureCreatedAsync(cancellationToken))
            {
                await InitVideoGameGenres(dbContext, cancellationToken);
                await InitDeveloperStudios(dbContext, cancellationToken);
            }
        }
        private static async Task InitVideoGameGenres(VideoGamesDbContext dbContext,
            CancellationToken cancellationToken = default)
        {
            await dbContext.VideoGameGenres.AddRangeAsync(new List<VideoGameGenre>() {
                new VideoGameGenre() { Name = "Экшен" },
                new VideoGameGenre() { Name = "Шутер" },
                new VideoGameGenre() { Name = "Ролевая игра" },
                new VideoGameGenre() { Name = "Стратегия" },
                new VideoGameGenre() { Name = "Приключенческая игра" },
                new VideoGameGenre() { Name = "Симулятор" },
                new VideoGameGenre() { Name = "Спортивная игра" },
                new VideoGameGenre() { Name = "Гонки" },
                new VideoGameGenre() { Name = "РПГ" },
                new VideoGameGenre() { Name = "ММО" },
                new VideoGameGenre() { Name = "VR" },
            },
               cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        private static async Task InitDeveloperStudios(VideoGamesDbContext dbContext,
            CancellationToken cancellationToken = default)
        {
                await dbContext.DeveloperStudios.AddRangeAsync(new List<DeveloperStudio>() {
                new DeveloperStudio() { Name = "Ubisoft" },
                new DeveloperStudio() { Name = "RockStar Games" },
                new DeveloperStudio() { Name = "Electronic Arts" },
                new DeveloperStudio() { Name = "Valve Corporation" },
                new DeveloperStudio() { Name = "Electronic Arts" },
                new DeveloperStudio() { Name = "Blizzard" },
                new DeveloperStudio() { Name = "Nintendo" },
                new DeveloperStudio() { Name = "Sega" },
                new DeveloperStudio() { Name = "Sony" },
                new DeveloperStudio() { Name = "Infinity World" },
                new DeveloperStudio() { Name = "Capcom" },
            },
               cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
