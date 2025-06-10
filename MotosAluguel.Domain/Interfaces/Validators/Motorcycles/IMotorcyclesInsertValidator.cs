using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

public interface IMotorcyclesInsertValidator
{
    Task<bool> ValidateAsync(Motorcycle motorcycle);
}
