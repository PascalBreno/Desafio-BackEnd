using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Rentals;

public class RentalRiderCnhTypeValidator : IRentalValidator
{
    private readonly IRentalValidator _validator;

    private readonly IRiderReaderRepository _riderReaderRepository;

    public RentalRiderCnhTypeValidator(
        IRentalValidator validator,
        IRiderReaderRepository riderReaderRepository)
    {
        _validator = validator;
        _riderReaderRepository = riderReaderRepository;
    }

    public async Task<OperationResult> ValidateAsync(Rental rental)
    {
        var operationResult = await _validator.ValidateAsync(rental);

        if (operationResult.Success)
        {
            if (!await CnhIsValidAsync(rental.RiderId))
                return OperationResult.Fail("Dados incorretos.");
        }

        return operationResult;
    }

    private async Task<bool> CnhIsValidAsync(string riderId)
    {
        var cnh = await _riderReaderRepository.GetCnhTypeById(riderId);

        if (cnh != "A" || cnh == "AB" || cnh == "A+B" || cnh == "A,B")
            return false;

        return true;
    }
}