using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Riders.UpdateCnh;

public class RiderUpdateCnhValidator : IRiderUpdateCnhValidator
{
    public Task<OperationResult> ValidateAsync(string id, string imageCnh)
    {
        return Task.FromResult(OperationResult.Ok());
    }
}
