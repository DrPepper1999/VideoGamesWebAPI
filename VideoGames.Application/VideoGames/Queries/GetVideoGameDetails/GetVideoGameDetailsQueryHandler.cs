using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Application.Common.Exceptions;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameDetails
{
    public class GetVideoGameDetailsQueryHandler
        : IRequestHandler<GetVideoGameDetailsQuery, VideoGameDetailsVm>
    {
        private readonly IVideoGamesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVideoGameDetailsQueryHandler(IVideoGamesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<VideoGameDetailsVm> Handle(GetVideoGameDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var videoGame = await _dbContext.VideoGames
                .Include(db => db.DeveloperStudio)
                .Include(db => db.Genres)
                .FirstOrDefaultAsync(vg => vg.Id == request.Id, cancellationToken);

            if (videoGame == null)
            {
                throw new NotFoundException(nameof(VideoGame), request.Id);
            }

            return _mapper.Map<VideoGameDetailsVm>(videoGame);
        }
    }
}
