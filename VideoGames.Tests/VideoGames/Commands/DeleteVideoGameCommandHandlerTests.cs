using Microsoft.EntityFrameworkCore;
using VideoGames.Tests.Common;
using VideoGames.Application.VideoGames.Commands.DeleteVideoGame;
using VideoGames.Application.Common.Exceptions;

namespace VideoGames.Tests.VideoGames.Commands
{
    public class DeleteVideoGameCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteVideoGameHandler_Success()
        {
            //Arrange
            var handler = new DeleteVideoGameCommandHandler(Context);

            //Act
            var videoGameId = await handler.Handle(
                new DeleteVideoGameCommand
                {
                  Id = VideoGameContextFactory.VideoGameIdForDelete
                }, CancellationToken.None);

            // Assert
            Assert.Null(Context.VideoGames.SingleOrDefault(videoGame =>
             videoGame.Id == VideoGameContextFactory.VideoGameIdForDelete));
        }

        [Fact]
        public async Task DeleteVideoGameCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteVideoGameCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteVideoGameCommand
                {
                    Id = Guid.NewGuid()
                },
                CancellationToken.None));
        }
    }
}
