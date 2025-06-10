using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;

namespace MotosAluguel.Domain.Validators.Riders;

public class RiderCnhTypeValidator(
    IRiderInsertValidator insertValidator) : IRiderInsertValidator
{
    private readonly IRiderInsertValidator _insertValidator = insertValidator;

    public async Task<bool> ValidateAsync(Rider rider)
    {
        var isValid = await _insertValidator.ValidateAsync(rider);

        if (isValid)
        {
            if (CnhTypeIsValid(rider.Cnh))
                return false;

            return true;
        }

        return isValid;
    }

    private static bool CnhTypeIsValid(string cnh)
    {
        cnh = cnh.ToUpper();

        if (cnh == "A" || cnh =="B" || cnh == "A,B" || cnh == "A+B" || cnh == "AB")
            return true;

        return false;
    }
}
