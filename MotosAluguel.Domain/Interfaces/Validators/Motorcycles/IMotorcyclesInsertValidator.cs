using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

public interface IMotorcyclesInsertValidator
{
    Task<OperationResult> ValidateAsync(Motorcycle motorcycle);
}
