using System.ComponentModel.DataAnnotations;
using VideoGames.Application.Common.Mappings;
using VideoGames.Application.VideoGames.Commands.UpdateVideoGame;

namespace VideoGames.WebAPI.Models.VideoGames
{
    public class UpdateVideoGameDto : IMapWith<UpdateVideoGameCommand>
    {
        [Required]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? RelesesDate { get; set; }
        public double? Rating { get; set; }
        public Guid? DeveloperStudioId { get; set; }
        public IEnumerable<Guid>? GenreIds { get; set; }
    }
}
