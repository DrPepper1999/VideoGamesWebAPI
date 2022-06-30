using AutoMapper;
using Shouldly;
using VideoGames.Application.VideoGames.Queries.GetVideoGameList;
using VideoGames.Tests.Common;
using VideoGames.Persistence;

namespace VideoGames.Tests.VideoGames.Queries
{
    [Collection("QueryCollection")]
    public class GetVideoGameListQuetyHandlerTests
    {
        private readonly VideoGamesDbContext Context;
        private readonly IMapper Mapper;

        public GetVideoGameListQuetyHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetVideoGameListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetVideoGameListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetVideoGameListQuery
                {
                    
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<VideoGameListVm>();
            result.VideoGames.Count.ShouldBe(4);
        }

        [Fact]
        public async Task GetVideoGameListQueryHandler_SuccessDeveloperStudioName()
        {
            //Arrange
            var handler = new GetVideoGameListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetVideoGameListQuery
                {
                    DeveloperStudioName = "Studio3"
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<VideoGameListVm>();
            result.VideoGames.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetVideoGameListQueryHandler_SuccessVideoGameGenreName()
        {
            //Arrange
            var handler = new GetVideoGameListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetVideoGameListQuery
                {
                    VideoGameGenreName = "Шутер"
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<VideoGameListVm>();
            result.VideoGames.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetVideoGameListQueryHandler_SuccessVideoRatingMoreThan()
        {
            //Arrange
            var handler = new GetVideoGameListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetVideoGameListQuery
                {
                    RatingMoreThan = 6
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<VideoGameListVm>();
            result.VideoGames.Count.ShouldBe(1);
        }
    }
}
