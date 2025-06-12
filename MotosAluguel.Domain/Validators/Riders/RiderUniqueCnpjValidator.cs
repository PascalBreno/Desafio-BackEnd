using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;

namespace MotosAluguel.Domain.Validators.Riders;

public class RiderUniqueCnpjValidator : IRiderInsertValidator
{
    private readonly IRiderInsertValidator _insertValidator;

    private readonly IRiderReaderRepository _riderReaderRepository;

    public RiderUniqueCnpjValidator(
        IRiderInsertValidator insertValidator,
        IRiderReaderRepository riderReaderRepository)
    {
        _insertValidator = insertValidator;
        _riderReaderRepository = riderReaderRepository;
    }


    public async Task<bool> ValidateAsync(Rider rider)
    {
        Console.WriteLine("Entrou no RiderUniqueCnpjValidator!");

        var isValid = await _insertValidator.ValidateAsync(rider);

        Console.WriteLine("Finalizou validação básica!");
        if (isValid)
        {
            if (await _riderReaderRepository.ExistByCnpj(rider.Cnh))
                return false;

            return true;
        }

        return isValid;
    }
}