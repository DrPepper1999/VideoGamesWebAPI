using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Application.Common.Mappings;
using VideoGames.Application.VideoGames.Queries.GetVideoGameList;

namespace VideoGames.WebAPI.Models.VideoGames
{
    public class GetVideoGameListDto : IMapWith<GetVideoGameListQuery>
    {
        public double? RatingMoreThan { get; set; }
        public string? DeveloperStudioName { get; set; }
        public string? VideoGameGenreName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetVideoGameListDto, GetVideoGameListQuery>()
                .ForMember(videoGame => videoGame.RatingMoreThan,
                opt => opt.MapFrom(videoGameDto => videoGameDto.RatingMoreThan))
                .ForMember(videoGame => videoGame.DeveloperStudioName,
                opt => opt.MapFrom(videoGameDto => videoGameDto.DeveloperStudioName))
                .ForMember(videoGame => videoGame.VideoGameGenreName,
                opt => opt.MapFrom(videoGameDto => videoGameDto.VideoGameGenreName));
        }
    }
}
