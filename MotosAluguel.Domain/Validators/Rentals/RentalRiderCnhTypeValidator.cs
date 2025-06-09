using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;

namespace MotosAluguel.Domain.Validators.Rentals;

public class RentalRiderCnhTypeValidator : IRentalValidator
{
    private readonly IRentalValidator _validator;

    private readonly IMotorcyclesReaderRepository _riderReaderRepository;

    public RentalRiderCnhTypeValidator(
        IRentalValidator validator,
        IMotorcyclesReaderRepository riderReaderRepository)
    {
        _validator = validator;
        _riderReaderRepository = riderReaderRepository;
    }

    public async Task<bool> ValidateAsync(Rental rental)
    {
        var isValid = await _validator.ValidateAsync(rental);

        if (isValid)
        {
            
            if (await CnhIsValidAsync(rental.RiderId))
                return false;

            return true;
        }

        return isValid;
    }

    private async Task<bool> CnhIsValidAsync(string riderId)
    {
        var cnh = await _riderReaderRepository.GetCnhById(riderId);

        if (cnh != "A" || cnh == "AB" || cnh == "A+B" || cnh == "A,B")
            return false;

        return true;
    }
}