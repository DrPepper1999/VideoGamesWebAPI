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
                .ForMember(videoGameDto => videoGameDto.Name,
                opt => opt.MapFrom(videoGame => videoGame.Name))
                .ForMember(videoGameDto => videoGameDto.ReleaseDate,
                opt => opt.MapFrom(videoGame => videoGame.ReleaseDate))
                .ForMember(videoGameDto => videoGameDto.Rating,
                opt => opt.MapFrom(videoGame => videoGame.Rating))
                .ForMember(videoGameDto => videoGameDto.DeveloperStudioName,
                opt => opt.MapFrom(videoGame => videoGame.DeveloperStudioName))
                .ForMember(videoGameDto => videoGameDto.GenreNames,
                opt => opt.MapFrom(videoGame => videoGame.GenreNames));
        }
    }
}
