using FluentValidation;

namespace VideoGames.Application.VideoGames.Queries.GetVideoGameDetails
{
    public class GetVideoGameDetailsQueryValidator : AbstractValidator<GetVideoGameDetailsQuery>
    {
        public GetVideoGameDetailsQueryValidator()
        {
            RuleFor(videoGame => videoGame)
                .NotNull();
            RuleFor(videoGame => videoGame.Id)
                .NotNull()
                .NotEqual(Guid.Empty);
        }
    }
}
