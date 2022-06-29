using MediatR;

namespace VideoGames.Application.VideoGames.Commands.CreateVideoGame
{
    public class CreateVideoGameCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public Guid DeveloperStudioId { get; set; }
        public IEnumerable<Guid> GenreIds { get; set; } = new List<Guid>();
    }
}
