using VideoGames.Persistence;

namespace VideoGames.Tests.Common
{
    public abstract class TestCommandBase : IDisposable 
    {
        protected readonly VideoGamesDbContext Context;

        public TestCommandBase()
        {
            Context = VideoGameContextFactory.Create();
        }

        public void Dispose()
        {
            VideoGameContextFactory.Destroy(Context);
        }
    }
}
