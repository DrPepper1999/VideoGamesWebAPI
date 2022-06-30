using Microsoft.EntityFrameworkCore;
using VideoGames.Tests.Common;
using VideoGames.Application.VideoGames.Commands.DeleteVideoGame;
using VideoGames.Application.Common.Exceptions;
using VideoGames.Application.VideoGames.Commands.UpdateVideoGame;

namespace VideoGames.Tests.VideoGames.Commands
{
    public class UpdateVideoGameCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateVideoGameHandler_Success()
        {
            //Arrange
            var handler = new UpdateVideoGameCommandHandler(Context);
            var videoGameName = "GameTestUpdate";
            var videoGameReleaseDate = new DateTime(2020, 5, 12);
            var videoGameRating = 8;
            var videoGameDeveloperStudioName = "Studio3";
            var videoGameGenreNames = new List<string>() { "Гонки", "Шутер" };

            //Act
            var videoGameId = await handler.Handle(
                new UpdateVideoGameCommand
                {
                    Id = VideoGameContextFactory.VideoGameIdForUpdate,
                    Name = videoGameName,
                    ReleaseDate = videoGameReleaseDate,
                    Rating = videoGameRating,
                    DeveloperStudioName = videoGameDeveloperStudioName,
                    GenreNames = videoGameGenreNames
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.VideoGames.SingleOrDefaultAsync(videoGame =>
                videoGame.Id == VideoGameContextFactory.VideoGameIdForUpdate && videoGame.Name == videoGameName &&
                videoGame.ReleaseDate == videoGameReleaseDate && videoGame.Rating == videoGameRating &&
                videoGame.DeveloperStudio.Name == videoGameDeveloperStudioName));
        }

        [Fact]
        public async Task UpdateVideoGameCommandHandler_FailOnWrongDeveloperStudio()
        {
            //Arrange
            var handler = new UpdateVideoGameCommandHandler(Context);
            var videoGameDeveloperStudioName = "Wrong";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateVideoGameCommand
                {
                    Id = VideoGameContextFactory.VideoGameIdForUpdate,
                    DeveloperStudioName = videoGameDeveloperStudioName,
                },
                CancellationToken.None));
        }

        [Fact]
        public async Task UpdateVideoGameCommandHandler_FailOnWrongVideoGameGenres()
        {
            //Arrange
            var handler = new UpdateVideoGameCommandHandler(Context);
            var videoGameGenreNames = new List<string>() { "РПГ", "Wrong" };

            //Act
            //Assert
            await Assert.ThrowsAsync<GenreDoesNotExist>(async () =>
            await handler.Handle(
                new UpdateVideoGameCommand
                {
                    Id = VideoGameContextFactory.VideoGameIdForUpdate,
                    GenreNames = videoGameGenreNames
                },
                CancellationToken.None));
        }
    }
}
