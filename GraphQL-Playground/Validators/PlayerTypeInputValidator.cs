using FluentValidation;
using GraphQL_Playground.GraphQL.Players;

namespace GraphQL_Playground.Validators
{
    public class PlayerTypeInputValidator : AbstractValidator<AddPlayerInput>
    {
        public PlayerTypeInputValidator()
        {
            RuleFor(r => r.name)
                .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("Player name must be between 3 and 30 characters.")
                .WithErrorCode("400");

            RuleFor(x => x.nationality)
                 .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("Player nationality must be between 3 and 30 characters.")
                .WithErrorCode("400");

            RuleFor(x => x.position)
                .MinimumLength(2)
               .MaximumLength(4)
               .WithMessage("Player position must be between 2 and 4 characters.")
               .WithErrorCode("400");

            RuleFor(x => x.teamId)
                .NotNull()
                .WithMessage("TeamId is required.")
                .WithErrorCode("400");

        }
    }
}
