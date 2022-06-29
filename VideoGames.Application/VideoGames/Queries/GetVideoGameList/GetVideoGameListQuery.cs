using MediatR;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameList
{
    public class GetVideoGameListQuery : IRequest<VideoGameListVm>
    {
        public Guid Id { get; set; }
        public double? RatingMoreThan { get; set; }
        public Guid? DeveloperStudioId { get; set; }
        public Guid? VideoGameGenreId { get; set; }
    }
}
