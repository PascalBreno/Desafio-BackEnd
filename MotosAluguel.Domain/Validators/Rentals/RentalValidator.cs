using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Rentals;

public class RentalValidator : IRentalValidator
{

    public Task<OperationResult> ValidateAsync(Rental rental)
    {
        return Task.FromResult(OperationResult.Ok());
    }
}
