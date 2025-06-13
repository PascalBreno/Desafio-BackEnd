using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;
using MotosAluguel.Domain.Validators.Base;

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

    public async Task<OperationResult> ValidateAsync(Rental rental)
    {
        var operationResult = await _validator.ValidateAsync(rental);

        if (operationResult.Success)
        {
            var existRider = await _riderReaderRepository.ExistById(rental.RiderId);

            if (!existRider)
                return OperationResult.Fail("Piloto não cadastrado");
        }

        return operationResult;
    }
}
