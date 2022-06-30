using AutoMapper;
using VideoGames.Application.Common.Mappings;
using VideoGames.Domain;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameDetails
{
    public class VideoGameDetailsVm : IMapWith<VideoGame>
    {
        public string Name { get; set; } = "";
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public string DeveloperStudio { get; set; }
        public ICollection<string> Genres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VideoGame, VideoGameDetailsVm>()
                .ForMember(videoGameVm => videoGameVm.Name,
                opt => opt.MapFrom(videoGame => videoGame.Name))
                .ForMember(videoGameVm => videoGameVm.ReleaseDate,
                opt => opt.MapFrom(videoGame => videoGame.ReleaseDate))
                .ForMember(videoGameVm => videoGameVm.Rating,
                opt => opt.MapFrom(videoGame => videoGame.Rating))
                .ForMember(videoGameVm => videoGameVm.DeveloperStudio,
                opt => opt.MapFrom(videoGame => videoGame.DeveloperStudio.Name))
                .ForMember(videoGameVm => videoGameVm.Genres,
                opt => opt.MapFrom(videoGame => videoGame.Genres.Select(genre => genre.Name)));
        }
    }
}
