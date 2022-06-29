using MediatR;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameDetails
{
    public class GetVideoGameDetailsQuery : IRequest<VideoGameDetailsVm>
    {
        public Guid Id { get; set; }

    }
}
