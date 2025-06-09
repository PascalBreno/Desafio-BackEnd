using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;

namespace MotosAluguel.Domain.Validators.Rentals;

public class RentalValidator : IRentalValidator
{
    private readonly IRentalValidator _validator;

    public async Task<bool> ValidateAsync(Rental rental)
    {
        return await _validator.ValidateAsync(rental);
    }
}
