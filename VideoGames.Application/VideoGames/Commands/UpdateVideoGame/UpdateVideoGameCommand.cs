using MediatR;

namespace VideoGames.Application.VideoGames.Commands.UpdateVideoGame
{
    public class UpdateVideoGameCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double? Rating { get; set; }
        public string? DeveloperStudioName { get; set; }
        public IEnumerable<string>? GenreNames { get; set; }
    }
}
