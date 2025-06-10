using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

namespace MotosAluguel.Domain.Validators.Motorcycles;

public class MotorcyclesUniquePlateValidator(
    IMotorcyclesInsertValidator validator,
    IMotorcyclesReadRepository motorcycleReadRepository) : IMotorcyclesInsertValidator
{
    private readonly IMotorcyclesInsertValidator _validator = validator;

    private readonly IMotorcyclesReadRepository _motorcycleReadRepository = motorcycleReadRepository;

    public async Task<bool> ValidateAsync(Motorcycle motorcycle)
    {
        var isValid = await _validator.ValidateAsync(motorcycle);

        if (isValid) {
            if (await _motorcycleReadRepository.ExistByPlateAsync(motorcycle.Plate))
                return false;

            return true;
        }

        return isValid;
    }
}
