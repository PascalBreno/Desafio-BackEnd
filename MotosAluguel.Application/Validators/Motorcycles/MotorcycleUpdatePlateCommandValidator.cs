using FluentValidation;
using MotosAluguel.Application.Commands.Motorcycles;

namespace MotosAluguel.Application.Validators.Motorcycles;

public class MotorcycleUpdatePlateCommandValidator : AbstractValidator<MotorcycleUpdatePlateCommand>
{
    public MotorcycleUpdatePlateCommandValidator()
    {
        RuleFor(x => x.Plate)
            .NotEmpty()
            .WithMessage("O identificador da moto não pode ser vazio.");
    }
}
