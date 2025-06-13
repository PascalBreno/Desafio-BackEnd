using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Interfaces.Validators.Riders;

public interface IRiderInsertValidator
{
    Task<OperationResult> ValidateAsync(Rider rider);
}
