using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Motorcycles.Insert;

public class MotorcyclesValidator : IMotorcyclesInsertValidator
{
    public Task<OperationResult> ValidateAsync(Motorcycle motorcycle)
    {
        return Task.FromResult(OperationResult.Ok());
    }
}