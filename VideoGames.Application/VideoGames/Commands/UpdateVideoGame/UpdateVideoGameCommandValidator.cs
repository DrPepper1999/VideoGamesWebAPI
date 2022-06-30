using FluentValidation;

namespace VideoGames.Application.VideoGames.Commands.UpdateVideoGame
{
    public class UpdateVideoGameCommandValidator : AbstractValidator<UpdateVideoGameCommand>
    {
        public UpdateVideoGameCommandValidator()
        {
            RuleFor(updateVgCommand => updateVgCommand)
                .NotNull();
            RuleFor(updateVgCommand => updateVgCommand.Id)
                .NotEqual(Guid.Empty)
                .NotNull();
            RuleFor(updateVgCommand => updateVgCommand.Rating)
                .InclusiveBetween(0, 10);
        }
    }
}
