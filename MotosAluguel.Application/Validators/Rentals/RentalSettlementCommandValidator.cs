using FluentValidation;
using MotosAluguel.Application.Commands.Rentals;

namespace MotosAluguel.Application.Validators.Rentals;

public class RentalSettlementCommandValidator : AbstractValidator<RentalSettlementCommand>
{
    public RentalSettlementCommandValidator()
    {
        RuleFor(x => x.Data_devolucao)
            .NotEmpty()
            .WithMessage("Data_devolucao is required.");
    }
}
