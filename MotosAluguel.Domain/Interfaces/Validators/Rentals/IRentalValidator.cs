using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Interfaces.Validators.Rentals;

public interface IRentalValidator
{
    Task<OperationResult> ValidateAsync(Rental rental);
}
