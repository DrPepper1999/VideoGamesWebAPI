using MediatR;
using AutoMapper;
using VideoGames.Application.Common.Mappings;
using VideoGames.Domain;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameList
{
    public class VideoGameLookupDto : IMapWith<VideoGame>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VideoGame, VideoGameLookupDto>()
                .ForMember(videoGameDto => videoGameDto.Id,
                opt => opt.MapFrom(videoGame => videoGame.Id))
                .ForMember(videoGameDto => videoGameDto.Name,
                opt => opt.MapFrom(videoGame => videoGame.Name))
                .ForMember(videoGameDto => videoGameDto.ReleaseDate,
                opt => opt.MapFrom(videoGame => videoGame.RelesesDate))
                .ForMember(videoGameDto => videoGameDto.Rating,
                opt => opt.MapFrom(videoGame => videoGame.Rating));
        }
    }
}
