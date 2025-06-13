using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Riders.Insert;

public class RiderUniqueCnhValidator : IRiderInsertValidator
{
    private readonly IRiderInsertValidator _insertValidator;

    private readonly IRiderReaderRepository _riderReaderRepository;

    public RiderUniqueCnhValidator(
        IRiderReaderRepository riderReaderRepository,
        IRiderInsertValidator insertValidator)
    {
        _riderReaderRepository = riderReaderRepository;
        _insertValidator = insertValidator;
    }

    public async Task<OperationResult> ValidateAsync(Rider rider)
    {
        var operationResult = await _insertValidator.ValidateAsync(rider);

        if (operationResult.Success)
        {
            var riderReaderExist = await _riderReaderRepository.ExistByCnh(rider.Cnh);

            if (riderReaderExist)
                return OperationResult.Fail("CNPJ já cadastrado") ;
        }

        return operationResult;
    }
}
