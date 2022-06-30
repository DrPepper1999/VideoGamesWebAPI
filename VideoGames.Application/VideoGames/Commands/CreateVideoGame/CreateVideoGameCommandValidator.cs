using FluentValidation;

namespace VideoGames.Application.VideoGames.Commands.CreateVideoGame
{
    public class CreateVideoGameCommandValidator : AbstractValidator<CreateVideoGameCommand>
    {
        public CreateVideoGameCommandValidator()
        {
            RuleFor(createVgCommand => createVgCommand)
                .NotNull();
            RuleFor(createVgCommand => createVgCommand.Name)
                .NotEmpty()
                .NotNull();
            RuleFor(createVgCommand => createVgCommand.ReleaseDate)
                .NotEmpty()
                .NotNull();
            RuleFor(createVgCommand => createVgCommand.Rating)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(0, 10);
            RuleFor(createVgCommand => createVgCommand.DeveloperStudioName)
                .NotEmpty()
                .NotNull();
            RuleFor(createVgCommand => createVgCommand.GenreNames)
                .NotEmpty()
                .NotNull();
        }
    }
}
