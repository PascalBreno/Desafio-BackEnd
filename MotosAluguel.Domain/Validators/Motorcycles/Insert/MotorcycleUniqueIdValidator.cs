using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Motorcycles.Insert;

public class MotorcycleUniqueIdValidator : IMotorcyclesInsertValidator
{
    private readonly IMotorcyclesInsertValidator _validator;
    private readonly IMotorcyclesReadRepository _repository;

    public MotorcycleUniqueIdValidator(
        IMotorcyclesInsertValidator validator,
        IMotorcyclesReadRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<OperationResult> ValidateAsync(Motorcycle motorcycle)
    {
        var operationResult = await _validator.ValidateAsync(motorcycle);

        if (operationResult.Success)
        {
            var existMotorcycle = await _repository.ExistById(motorcycle.Id);

            if (existMotorcycle)
                return OperationResult.Fail("Moto já cadastrada");
        }

        return operationResult;
    }
}
