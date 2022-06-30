using Microsoft.EntityFrameworkCore;
using VideoGames.Domain;
using VideoGames.Persistence;

namespace VideoGames.Tests.Common
{
    public class VideoGameContextFactory
    {
        public static Guid VideoGameA = Guid.NewGuid();

        public static Guid VideoGameIdForDelete = Guid.NewGuid();
        public static Guid VideoGameIdForUpdate = Guid.NewGuid();

        public static VideoGamesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<VideoGamesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new VideoGamesDbContext(options);
            context.Database.EnsureCreated();

            var studio1 = new DeveloperStudio
            {
                Id = Guid.Parse("5067A6D5-E252-4DB2-8FD5-0FAE21605B40"),
                Name = "Studio1",
            };
            var studio2 = new DeveloperStudio
            {
                Id = Guid.Parse("7DE5046A-2027-40FF-A6D8-49B678162F3D"),
                Name = "Studio2",
            };
            var studio3 = new DeveloperStudio
            {
                Id = Guid.Parse("FDBA2F3B-F56A-464E-893F-541B59CE57A0"),
                Name = "Studio3",
            };

            var genre1 = new VideoGameGenre
            {
                Id = Guid.Parse("C4DCA42A-7A08-46F5-B73F-AC5AAC865F09"),
                Name = "РПГ",
            };
            var genre2 = new VideoGameGenre
            {
                Id = Guid.Parse("E1A52308-1D2A-4E99-A87D-9CD8DC458F8A"),
                Name = "Шутер",
            };
            var genre3 = new VideoGameGenre
            {
                Id = Guid.Parse("F606DB09-3F41-4C33-8492-849C4C5B856F"),
                Name = "Гонки",
            };

            context.VideoGames.AddRange(
                new VideoGame
                {
                    Id = VideoGameIdForDelete,
                    Name = "Game1",
                    ReleaseDate = DateTime.Now,
                    Rating = 5.5,
                    DeveloperStudio = studio1,
                    Genres = new List<VideoGameGenre>() { genre1, genre2, genre3}
                },
                new VideoGame
                {
                    Id = VideoGameIdForUpdate,
                    Name = "Game2",
                    ReleaseDate = DateTime.Now,
                    Rating = 5.5,
                    DeveloperStudio = studio2,
                    Genres = new List<VideoGameGenre>() { genre2, genre3 }
                },              
                new VideoGame
                {
                    Id = VideoGameA,
                    Name = "Game3",
                    ReleaseDate = new DateTime(2022, 7, 1),
                    Rating = 5.5,
                    DeveloperStudio = studio3,
                    Genres = new List<VideoGameGenre>() { genre3 }
                }, 
                new VideoGame
                {
                    Id = Guid.Parse("B46A8F93-15DD-44D9-AB6B-745FCEE6BE8F"),
                    Name = "Game4",
                    ReleaseDate = new DateTime(2022, 8, 1),
                    Rating = 7.5,
                    DeveloperStudio = studio3,
                    Genres = new List<VideoGameGenre>() { genre3 }
                }

            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(VideoGamesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
