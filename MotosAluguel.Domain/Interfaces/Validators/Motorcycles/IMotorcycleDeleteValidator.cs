namespace MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

public interface IMotorcycleDeleteValidator
{
    Task<bool> ValidateAsync(string id);
}
