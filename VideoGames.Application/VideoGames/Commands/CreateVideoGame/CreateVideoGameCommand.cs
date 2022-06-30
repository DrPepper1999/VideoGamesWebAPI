using MediatR;

namespace VideoGames.Application.VideoGames.Commands.CreateVideoGame
{
    public class CreateVideoGameCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public string DeveloperStudioName { get; set; }
        public IEnumerable<string> GenreNames { get; set; } = new List<string>();
    }
}
