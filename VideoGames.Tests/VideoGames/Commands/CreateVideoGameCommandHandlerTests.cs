using Microsoft.EntityFrameworkCore;
using VideoGames.Tests.Common;
using VideoGames.Application.VideoGames.Commands.CreateVideoGame;

using Xunit;
using VideoGames.Application.Common.Exceptions;

namespace VideoGames.Tests.VideoGames.Commands
{
    public class CreateVideoGameCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateVideoGameHandler_Success()
        {
            //Arrange
            var handler = new CreateVideoGameCommandHandler(Context);
            var videoGameName = "GameTest1";
            var videoGameReleaseDate = new DateTime(2022, 6, 30);
            var videoGameRating = 5;
            var videoGameDeveloperStudioName = "Studio1";
            var videoGameGenreNames = new List<string>() { "Гонки", "Шутер" };

            //Act
            var videoGameId = await handler.Handle(
                new CreateVideoGameCommand
                {
                    Name = videoGameName,
                    ReleaseDate = videoGameReleaseDate,
                    Rating = videoGameRating,
                    DeveloperStudioName = videoGameDeveloperStudioName,
                    GenreNames = videoGameGenreNames
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.VideoGames.SingleOrDefaultAsync(videoGame =>
                videoGame.Id == videoGameId && videoGame.Name == videoGameName &&
                videoGame.ReleaseDate == videoGameReleaseDate &&
                videoGame.Rating == videoGameRating &&
                videoGame.DeveloperStudio.Name == videoGameDeveloperStudioName));
        }

        [Fact]
        public async Task CreateVideoGameCommandHandler_FailOnWrongDeveloperStudio()
        {
            //Arrange
            var handler = new CreateVideoGameCommandHandler(Context);
            var videoGameName = "GameTest1";
            var videoGameReleaseDate = new DateTime(2022, 6, 30);
            var videoGameRating = 5;
            var videoGameDeveloperStudioName = "Wrong";
            var videoGameGenreNames = new List<string>() { "Гонки", "Шутер" };

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new CreateVideoGameCommand
                {
                    Name = videoGameName,
                    ReleaseDate = videoGameReleaseDate,
                    Rating = videoGameRating,
                    DeveloperStudioName = videoGameDeveloperStudioName,
                    GenreNames = videoGameGenreNames
                },
                CancellationToken.None));
        }

        [Fact]
        public async Task CreateVideoGameCommandHandler_FailOnWrongVideoGameGenres()
        {
            //Arrange
            var handler = new CreateVideoGameCommandHandler(Context);
            var videoGameName = "GameTest1";
            var videoGameReleaseDate = new DateTime(2022, 6, 30);
            var videoGameRating = 5;
            var videoGameDeveloperStudioName = "Studio1";
            var videoGameGenreNames = new List<string>() { "Гонки", "Wrong" };

            //Act
            //Assert
            await Assert.ThrowsAsync<GenreDoesNotExist>(async () =>
            await handler.Handle(
                new CreateVideoGameCommand
                {
                    Name = videoGameName,
                    ReleaseDate = videoGameReleaseDate,
                    Rating = videoGameRating,
                    DeveloperStudioName = videoGameDeveloperStudioName,
                    GenreNames = videoGameGenreNames
                },
                CancellationToken.None));
        }
    }
}
