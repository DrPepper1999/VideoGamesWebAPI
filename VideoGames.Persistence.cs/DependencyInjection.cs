using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;
using VideoGames.Application.Interfaces;

namespace VideoGames.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<VideoGamesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IVideoGamesDbContext>(provider =>
                provider.GetService<VideoGamesDbContext>());

            return services;
        }
        public static async Task InitPersistenceAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
        {
            using var scope = services.CreateScope();
            var provider = scope.ServiceProvider;
            try
            {
                var dbContext = provider.GetRequiredService<VideoGamesDbContext>();
                await DbInitializer.InitializeAsync(dbContext, cancellationToken);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "An error occurred while app initialization");
            }
        }
    }
}
