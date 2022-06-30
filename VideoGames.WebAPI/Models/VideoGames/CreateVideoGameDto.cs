using System.ComponentModel.DataAnnotations;
using AutoMapper;
using VideoGames.Application.Common.Mappings;
using VideoGames.Application.VideoGames.Commands.CreateVideoGame;

namespace VideoGames.WebAPI.Models.VideoGames
{
    public class CreateVideoGameDto : IMapWith<CreateVideoGameCommand>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string DeveloperStudioName { get; set; }
        [Required]
        public IEnumerable<string> GenreNames { get; set; } = new List<string>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateVideoGameDto, CreateVideoGameCommand>()
                .ForMember(videoGame => videoGame.Name,
                opt => opt.MapFrom(videoGameDto => videoGameDto.Name))
                .ForMember(videoGame => videoGame.ReleaseDate,
                opt => opt.MapFrom(videoGameDto => videoGameDto.ReleaseDate))
                .ForMember(videoGame => videoGame.Rating,
                opt => opt.MapFrom(videoGameDto => videoGameDto.Rating))
                .ForMember(videoGame => videoGame.DeveloperStudioName,
                opt => opt.MapFrom(videoGameDto => videoGameDto.DeveloperStudioName))
                .ForMember(videoGame => videoGame.GenreNames,
                opt => opt.MapFrom(videoGameDto => videoGameDto.GenreNames));
        }
    }
}
