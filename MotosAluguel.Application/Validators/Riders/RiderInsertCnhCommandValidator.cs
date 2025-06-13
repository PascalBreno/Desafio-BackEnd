using FluentValidation;
using MotosAluguel.Application.Commands.Riders;

namespace MotosAluguel.Application.Validators.Riders;

public class RiderInsertCnhCommandValidator : AbstractValidator<RiderInsertCnhCommand>
{
    public RiderInsertCnhCommandValidator()
    {
        RuleFor(x => x.Imagem_cnh)
            .NotEmpty()
            .WithMessage("Imagem_cnh não pode ser vazio.");
    }
}
