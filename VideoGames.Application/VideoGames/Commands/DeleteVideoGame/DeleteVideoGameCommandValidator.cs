using FluentValidation;

namespace VideoGames.Application.VideoGames.Commands.DeleteVideoGame
{
    public class DeleteVideoGameCommandValidator : AbstractValidator<DeleteVideoGameCommand>
    {
        public DeleteVideoGameCommandValidator()
        {
            RuleFor(deleteVgCommand => deleteVgCommand)
                .NotNull();
            RuleFor(deleteVgCommand => deleteVgCommand.Id)
                .NotEqual(Guid.Empty)
                .NotNull();
        }
    }
}
