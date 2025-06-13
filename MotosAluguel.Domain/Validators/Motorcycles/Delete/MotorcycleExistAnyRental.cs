using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

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


    public async Task<OperationResult> ValidateAsync(string id)
    {
        var operationResult = await _validator.ValidateAsync(id);

        if (operationResult.Success)
        {
            var rentalExist = await _rentalReaderRepository.ExistAnyRentalByMotorcycleId(id);

            if (rentalExist)
                return OperationResult.Fail("Não é possível excluir a moto, pois ela está vinculada a uma locação.");

        }

        return operationResult;
    }
}
