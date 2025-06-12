using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

namespace MotosAluguel.Domain.Validators.Motorcycles.Delete;

public class MotorcycleExistAnyRental : IMotorcycleDeleteValidator
{
    private readonly IRentalReaderRepository _rentalReaderRepository;

    private readonly IMotorcycleDeleteValidator _validator;

    public MotorcycleExistAnyRental(
        IRentalReaderRepository rentalReaderRepository,
        IMotorcycleDeleteValidator validator)
    {
        _rentalReaderRepository = rentalReaderRepository;
        _validator = validator;
    }

    public async Task<bool> ValidateAsync(string id)
    {
        var isValid = await _validator.ValidateAsync(id);

        if (isValid)
            return !await _rentalReaderRepository.ExistAnyRentalByMotorcycleId(id);

        return isValid;
    }
}
