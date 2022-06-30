using AutoMapper;
using System.ComponentModel.DataAnnotations;
using VideoGames.Application.Common.Mappings;
using VideoGames.Application.VideoGames.Commands.UpdateVideoGame;

namespace VideoGames.WebAPI.Models.VideoGames
{
    public class UpdateVideoGameDto : IMapWith<UpdateVideoGameCommand>
    {
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double? Rating { get; set; }
        public string? DeveloperStudioName { get; set; }
        public IEnumerable<string>? GenreNames { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateVideoGameDto, UpdateVideoGameCommand>()
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
