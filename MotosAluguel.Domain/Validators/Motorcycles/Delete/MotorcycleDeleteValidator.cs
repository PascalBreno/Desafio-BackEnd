using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Motorcycles.Delete;

public class MotorcycleDeleteValidator : IMotorcycleDeleteValidator
{
    public Task<OperationResult> ValidateAsync(string id)
    {
        var operationResult = OperationResult.Ok();

        return Task.FromResult(operationResult);
    }
}
