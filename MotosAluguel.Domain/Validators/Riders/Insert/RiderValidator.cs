using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Riders.Insert;

public class RiderValidator : IRiderInsertValidator
{
    public Task<OperationResult> ValidateAsync(Rider entity)
    {
        return Task.FromResult(OperationResult.Ok());
    }
}
