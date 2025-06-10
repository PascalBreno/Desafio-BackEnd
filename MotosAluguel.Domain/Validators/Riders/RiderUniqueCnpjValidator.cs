using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;

namespace MotosAluguel.Domain.Validators.Riders;

public class RiderUniqueCnpjValidator(
    IRiderInsertValidator insertValidator,
    IRiderReaderRepository riderReaderRepository) : IRiderInsertValidator
{
    private readonly IRiderInsertValidator _insertValidator = insertValidator;

    private readonly IRiderReaderRepository _riderReaderRepository = riderReaderRepository;

public async Task<bool> ValidateAsync(Rider rider)
{
    var isValid = await _insertValidator.ValidateAsync(rider);

    if (isValid)
    {
        if (await _riderReaderRepository.ExistByCnpj(rider.Cnh))
            return false;

        return true;
    }

    return isValid;
}
}