using MotosAluguel.Domain.Entities.Rentals;

namespace MotosAluguel.Domain.Interfaces.Validators.Rentals;

public interface IRentalValidator
{
    Task<bool> ValidateAsync(Rental rental);
}
