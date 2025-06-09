using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;

namespace MotosAluguel.Domain.Validators.Rentals;

public class RentalRiderExistValidator : IRentalValidator
{
    private readonly IRentalValidator _validator;

    private readonly IRiderReaderRepository _riderReaderRepository;

    public RentalRiderExistValidator(
        IRentalValidator validator,
        IRiderReaderRepository motorcycleReadRepository)
    {
        _validator = validator;
        _riderReaderRepository = motorcycleReadRepository;
    }

    public async Task<bool> ValidateAsync(Rental rental)
    {
        var isValid = await _validator.ValidateAsync(rental);

        if (isValid)
        {
            if (!await _riderReaderRepository.ExistById(rental.RiderId))
                return false;

            return true;
        }

        return isValid;
    }
}
