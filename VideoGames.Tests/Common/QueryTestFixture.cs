using AutoMapper;
using VideoGames.Application.Common.Mappings;
using VideoGames.Application.Interfaces;
using VideoGames.Persistence;
using Xunit;

namespace VideoGames.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public VideoGamesDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = VideoGameContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(IVideoGamesDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            VideoGameContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
