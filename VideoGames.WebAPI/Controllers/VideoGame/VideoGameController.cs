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
    [Produces("application/json")]
    public class VideoGameController : BaseController
    {
        private readonly IMapper _mapper;
        public VideoGameController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of videoGames 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /VideoGame/GetAll
        /// {
        ///     videoGameGenreName: "videoGame genre name"
        ///     developerStudioName: "developer studio name"
        ///     ratingMoreThan: "videoGames rating more than"
        /// }
        /// </remarks>
        /// <param name="getVideoGameListDto">GetVideoGameListDto object</param>
        /// <returns>Retuns VideoGameListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VideoGameListVm>> GetAll
            ([FromQuery] GetVideoGameListDto getVideoGameListDto)
        {
            var query = _mapper.Map<GetVideoGameListQuery>(getVideoGameListDto);
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the videoGame by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /VideoGame/Get/687A907E-DCCC-404C-933F-1EACC097F64D
        /// </remarks>
        /// <param name="id">VideoGame id (Guid)</param>
        /// <returns>Retuns VideoGameDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VideoGameDetailsVm>> Get(Guid id)
        {
            var query = new GetVideoGameDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the videoGame
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /VideoGame/Create
        /// {
        ///     name: "video game name"
        ///     releaseDate: "date of release"
        ///     rating: "rating"
        ///     developerStudioName: "developer studio name"
        ///     genreNames: "genre name"
        /// }
        /// </remarks>
        /// <param name="createVideoGameDto">CreateVideoGameDto object</param>
        /// <returns>Retuns id (Guid)</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateVideoGameDto createVideoGameDto)
        {
            var command = _mapper.Map<CreateVideoGameCommand>(createVideoGameDto);
            var videoGameId = await Mediator.Send(command);

            return Ok(videoGameId);
        }

        /// <summary>
        /// Updates the videoGame 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /VideoGame/Update/687A907E-DCCC-404C-933F-1EACC097F64D
        /// {
        ///     name: "video game name"
        ///     releaseDate: "date of release"
        ///     rating: "rating"
        ///     developerStudioName: "developer studio name"
        ///     genreNames: "genre name"
        /// }
        /// </remarks>
        /// <param name="id">videoGane id (Guid)</param>
        /// <param name="updateVideoGameDto">UpdateVideoGameDto object</param>
        /// <returns>Retuns NoContent</returns>
        /// <response code="200">Success</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(Guid id,
            [FromBody] UpdateVideoGameDto updateVideoGameDto)
        {
            var command = _mapper.Map<UpdateVideoGameCommand>(updateVideoGameDto);
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete the videoGame by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /VideoGame/Delete/687A907E-DCCC-404C-933F-1EACC097F64D
        /// </remarks>
        /// <param name="id">VideoGame id (Guid)</param>
        /// <returns>Retuns NoContent</returns>
        /// <response code="200">Success</response>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
