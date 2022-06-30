using FluentValidation;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameList
{
    public class GetVideoGameListQueryValidator : AbstractValidator<GetVideoGameListQuery>
    {
        public GetVideoGameListQueryValidator()
        {
            RuleFor(videoGame => videoGame)
                .NotNull();
        }
    }
}
