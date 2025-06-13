using FluentValidation;
using MotosAluguel.Application.Commands.Motorcycles;

namespace MotosAluguel.Application.Validators.Motorcycles;

public class MotorcycleInsertCommandValidator : AbstractValidator<MotorcycleInsertCommand>
{
    public MotorcycleInsertCommandValidator()
    {
        RuleFor(x => x.Identificador)
            .NotEmpty()
            .WithMessage("O identificador não pode ser vazio.");

    RuleFor(x => x.Modelo)
            .NotEmpty()
            .WithMessage("O modelo da moto é obrigatório.");

        RuleFor(x => x.Placa)
            .NotEmpty()
            .WithMessage("A placa da moto é obrigatória.");

        RuleFor(x => x.Ano)
            .NotEmpty()
            .WithMessage("O Ano é obrigatório");
    }
}
