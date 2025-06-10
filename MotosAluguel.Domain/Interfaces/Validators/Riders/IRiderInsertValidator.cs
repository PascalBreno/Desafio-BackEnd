using MotosAluguel.Domain.Entities.Riders;

namespace MotosAluguel.Domain.Interfaces.Validators.Riders;

public interface IRiderInsertValidator
{
    Task<bool> ValidateAsync(Rider rider);
}
