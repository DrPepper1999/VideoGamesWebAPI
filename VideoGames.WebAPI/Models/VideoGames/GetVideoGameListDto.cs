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
                .ForMember(videoGameDto => videoGameDto.RatingMoreThan,
                opt => opt.MapFrom(videoGame => videoGame.RatingMoreThan))
                .ForMember(videoGameDto => videoGameDto.DeveloperStudioName,
                opt => opt.MapFrom(videoGame => videoGame.DeveloperStudioName))
                .ForMember(videoGameDto => videoGameDto.VideoGameGenreName,
                opt => opt.MapFrom(videoGame => videoGame.VideoGameGenreName));
        }
    }
}
