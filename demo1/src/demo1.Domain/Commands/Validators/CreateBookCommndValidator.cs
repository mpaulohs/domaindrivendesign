using FluentValidation;

namespace demo1.Domain.Commands.Validators
{
    public class CreateBookCommndValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommndValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage("O Title é obrigatório");
        }
    }
}
