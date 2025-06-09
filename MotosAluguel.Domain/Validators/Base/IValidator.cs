namespace MotosAluguel.Domain.Validators.Base;

public interface IValidator<T>
{
    Task<bool> ValidateAsync(T entity);
}
