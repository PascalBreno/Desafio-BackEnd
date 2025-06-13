using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Interfaces.Validators.Riders;

public interface IRiderUpdateCnhValidator
{
    Task<OperationResult> ValidateAsync(string id, string imageCnh);
}