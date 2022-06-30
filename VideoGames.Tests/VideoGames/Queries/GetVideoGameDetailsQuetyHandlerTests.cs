using AutoMapper;
using Shouldly;
using VideoGames.Application.VideoGames.Queries.GetVideoGameDetails;
using VideoGames.Tests.Common;
using VideoGames.Persistence;


namespace VideoGames.Tests.VideoGames.Queries
{
    [Collection("QueryCollection")]
    public class GetVideoGameDetailsQuetyHandlerTests
    {
        private readonly VideoGamesDbContext Context;
        private readonly IMapper Mapper;

        public GetVideoGameDetailsQuetyHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetVideoGameDetailsQuetyHandler_Success()
        {
            // Arrange
            var handler = new GetVideoGameDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetVideoGameDetailsQuery
                {
                    Id = VideoGameContextFactory.VideoGameA
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<VideoGameDetailsVm>();
            result.Name.ShouldBe("Game3");
            result.ReleaseDate.ShouldBe(new DateTime(2022, 7, 1));
            result.Rating.ShouldBe(5.5);
        }
    }
}
