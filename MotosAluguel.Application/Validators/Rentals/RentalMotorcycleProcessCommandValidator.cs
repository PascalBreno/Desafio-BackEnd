using FluentValidation;
using MotosAluguel.Application.Commands.Rentals;

namespace MotosAluguel.Application.Validators.Rentals;

public class RentalMotorcycleProcessCommandValidator : AbstractValidator<RentalMotorcycleProcessCommand>
{
    public RentalMotorcycleProcessCommandValidator()
    {
        RuleFor(x => x.Entregador_id)
            .NotEmpty().WithMessage("Entregador_id é obrigatório.");

        RuleFor(x => x.Moto_id)
            .NotEmpty().WithMessage("Moto_id é obrigatório.");

        RuleFor(x => x.Data_inicio)
            .NotEmpty()
            .WithMessage("Data_inicio é obrigatório.");

        RuleFor(x => x.Data_termino)
            .NotEmpty()
            .WithMessage("Data_termino é obrigatório.");

        RuleFor(x => x.Data_previsao_termino)
            .NotEmpty()
            .WithMessage("Data_previsao_termino é obrigatório.");

        RuleFor(x => x.Plano)
            .NotEmpty()
            .WithMessage("Plano é obrigatório.");
    }
}
