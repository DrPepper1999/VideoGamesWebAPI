using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Application.Common.Exceptions;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameList
{
    public class GetVideoGameListQueryHandler
        : IRequestHandler<GetVideoGameListQuery, VideoGameListVm>
    {
        private readonly IVideoGamesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVideoGameListQueryHandler(IVideoGamesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<VideoGameListVm> Handle(GetVideoGameListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.VideoGames.AsQueryable();
            if (request.RatingMoreThan.HasValue)
            {
                query = query.Where(vg => vg.Rating > request.RatingMoreThan);
            }
            if (request.DeveloperStudioName != null)
            {
                query = query.Where(vg => vg.DeveloperStudio.Name == request.DeveloperStudioName);
            }
            if (request.VideoGameGenreName != null)
            {
                query = query.Where(vg => vg.Genres.Any(g => g.Name == request.VideoGameGenreName));
            }
            var videoGameQuery = await query
                .ProjectTo<VideoGameLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return new VideoGameListVm { VideoGames = videoGameQuery };
        }
    }
}
