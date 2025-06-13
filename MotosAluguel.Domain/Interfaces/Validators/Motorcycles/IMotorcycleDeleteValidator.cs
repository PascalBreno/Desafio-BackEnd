using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

public interface IMotorcycleDeleteValidator
{
    Task<OperationResult> ValidateAsync(string id);
}
