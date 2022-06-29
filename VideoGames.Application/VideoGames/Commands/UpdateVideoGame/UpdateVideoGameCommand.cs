using MediatR;

namespace VideoGames.Application.VideoGames.Commands.UpdateVideoGame
{
    public class UpdateVideoGameCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? RelesesDate { get; set; }
        public double? Rating { get; set; }
        public Guid? DeveloperStudioId { get; set; }
        public IEnumerable<Guid>? GenreIds { get; set; }
    }
}
