using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Riders.Insert;

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


    public async Task<OperationResult> ValidateAsync(Rider rider)
    {
        var operationResult = await _insertValidator.ValidateAsync(rider);

        if (operationResult.Success)
        {
            var existRider = await _riderReaderRepository.ExistByCnpj(rider.Cnpj);

            if (existRider)
                return OperationResult.Fail("CNPJ já cadastrado.");
        }

        return operationResult;
    }
}