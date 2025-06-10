using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;

namespace MotosAluguel.Domain.Validators.Rentals;

public class RentalMotorcycleExistValidator : IRentalValidator
{
    private readonly IRentalValidator _validator;

    private readonly IMotorcyclesReadRepository _motorcycleReadRepository;

    public RentalMotorcycleExistValidator(
        IRentalValidator validator,
        IMotorcyclesReadRepository motorcycleReadRepository)
    {
        _validator = validator;
        _motorcycleReadRepository = motorcycleReadRepository;
    }

    public async Task<bool> ValidateAsync(Rental rental)
    {
        var isValid = await _validator.ValidateAsync(rental);

        if (isValid)
        {
            if (!await _motorcycleReadRepository.ExistById(rental.MotorCycleId))
                return false;

            return true;
        }

        return isValid;
    }
}
