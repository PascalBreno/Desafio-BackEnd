using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

namespace MotosAluguel.Domain.Validators.Motorcycles.Delete;

public class MotorcycleDeleteValidator : IMotorcycleDeleteValidator
{
    public Task<bool> ValidateAsync(string id)
    {
        return Task.FromResult(true);
    }
}
