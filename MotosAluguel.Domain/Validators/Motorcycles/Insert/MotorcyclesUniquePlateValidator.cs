using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Motorcycles.Insert;

public class MotorcyclesUniquePlateValidator(
    IMotorcyclesInsertValidator validator,
    IMotorcyclesReadRepository motorcycleReadRepository) : IMotorcyclesInsertValidator
{
    private readonly IMotorcyclesInsertValidator _validator = validator;

    private readonly IMotorcyclesReadRepository _motorcycleReadRepository = motorcycleReadRepository;

    public async Task<OperationResult> ValidateAsync(Motorcycle motorcycle)
    {
        var operationResult = await _validator.ValidateAsync(motorcycle);

        if (operationResult.Success)
        {
            var existMotorcycle = await _motorcycleReadRepository.ExistByPlateAsync(motorcycle.Plate);

            if (existMotorcycle)
                return OperationResult.Fail("Placa já existe.");
        }

        return operationResult;
    }
}
