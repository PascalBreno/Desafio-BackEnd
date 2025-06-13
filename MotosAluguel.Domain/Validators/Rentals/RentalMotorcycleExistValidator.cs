using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;
using MotosAluguel.Domain.Validators.Base;

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

    public async Task<OperationResult> ValidateAsync(Rental rental)
    {
        var operationResult = await _validator.ValidateAsync(rental);

        if (operationResult.Success)
        {
            var motorcycleExists = await _motorcycleReadRepository.ExistById(rental.MotorCycleId);

            if (!motorcycleExists)
                return OperationResult.Fail("Motorcycle does not exist.");
            
        }
        
        return operationResult;
    }
}
