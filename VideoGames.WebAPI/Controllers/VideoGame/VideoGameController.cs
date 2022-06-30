using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGames.Application.VideoGames.Commands.CreateVideoGame;
using VideoGames.Application.VideoGames.Commands.DeleteVideoGame;
using VideoGames.Application.VideoGames.Commands.UpdateVideoGame;
using VideoGames.Application.VideoGames.Queries.GetVideoGameDetails;
using VideoGames.Application.VideoGames.Queries.GetVideoGameList;
using VideoGames.WebAPI.Models.VideoGames;

namespace VideoGames.WebAPI.Controllers.VideoGame
{
    public class VideoGameController : BaseController
    {
        private readonly IMapper _mapper;
        public VideoGameController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<VideoGameListVm>> GetAll
            ([FromQuery] GetVideoGameListDto getVideoGameListDto)
        {
            var query = _mapper.Map<GetVideoGameListQuery>(getVideoGameListDto);
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGameDetailsVm>> Get(Guid id)
        {
            var query = new GetVideoGameDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateVideoGameDto createVideoGameDto)
        {
            var command = _mapper.Map<CreateVideoGameCommand>(createVideoGameDto);
            var videoGameId = await Mediator.Send(command);

            return Ok(videoGameId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVideoGameDto updateVideoGameDto)
        {
            var command = _mapper.Map<UpdateVideoGameCommand>(updateVideoGameDto);
            var videoGameId = await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteVideoGameCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
