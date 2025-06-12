using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;

namespace MotosAluguel.Domain.Validators.Riders;

public class RiderValidator : IRiderInsertValidator
{
    public Task<bool> ValidateAsync(Rider entity)
    {
        return Task.FromResult(true);
    }
}
