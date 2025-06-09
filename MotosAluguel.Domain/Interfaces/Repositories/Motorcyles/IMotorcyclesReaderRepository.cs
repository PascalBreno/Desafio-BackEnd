using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

public interface IMotorcyclesReaderRepository
{
    Task<Motorcycle> GetByIdAsync(string id);

    Task<bool> ExistByPlateAsync(string plate);

    Task<bool> ExistById(string id);

    Task<string> GetCnhById(string id);
}
