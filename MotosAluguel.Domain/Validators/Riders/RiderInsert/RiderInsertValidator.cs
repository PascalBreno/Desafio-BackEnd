using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;

namespace MotosAluguel.Domain.Validators.Riders.RiderInsert;

public class RiderInsertValidator : IRiderInsertValidator
{
    private readonly IRiderInsertValidator _validator;

    public RiderInsertValidator(IRiderInsertValidator validator)
    {
        _validator = validator;
    }

    public async Task<bool> ValidateAsync(Rider entity)
    {
        return await _validator.ValidateAsync(entity);
    }
}
