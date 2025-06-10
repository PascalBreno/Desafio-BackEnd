using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;

namespace MotosAluguel.Domain.Validators.Rentals;

public class RentalValidator : IRentalValidator
{

    public Task<bool> ValidateAsync(Rental rental)
    {
        return Task.FromResult(true);
    }
}
