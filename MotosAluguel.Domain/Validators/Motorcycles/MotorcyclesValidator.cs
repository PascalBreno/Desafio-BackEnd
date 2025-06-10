using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

namespace MotosAluguel.Domain.Validators.Motorcycles;

public class MotorcyclesValidator : IMotorcyclesInsertValidator
{
    public Task<bool> ValidateAsync(Motorcycle motorcycle)
    {
        return Task.FromResult(true);
    }
}