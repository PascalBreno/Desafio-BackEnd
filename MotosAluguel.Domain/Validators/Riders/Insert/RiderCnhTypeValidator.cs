using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Domain.Validators.Riders.Insert;

public class RiderCnhTypeValidator : IRiderInsertValidator
{
    private readonly IRiderInsertValidator _insertValidator;

    public RiderCnhTypeValidator(IRiderInsertValidator insertValidator)
    {
        _insertValidator = insertValidator;
    }

    public async Task<OperationResult> ValidateAsync(Rider rider)
    {
        var operationResult = await _insertValidator.ValidateAsync(rider);

        if (operationResult.Success)
        {
            if (!CnhTypeIsValid(rider.CnhType))
                return OperationResult.Fail("Tipo de CNH inválido.");
        }

        return operationResult;
    }

    private static bool CnhTypeIsValid(string cnh)
    {
        cnh = cnh.ToUpper();

        if (cnh == "A" || cnh =="B" || cnh == "A,B" || cnh == "A+B" || cnh == "AB")
            return true;

        return false;
    }
}
