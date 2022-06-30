using MediatR;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameList
{
    public class GetVideoGameListQuery : IRequest<VideoGameListVm>
    {
        public double? RatingMoreThan { get; set; }
        public string? DeveloperStudioName { get; set; }
        public string? VideoGameGenreName { get; set; }
    }
}
