using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

public interface IMotorcyclesReadRepository
{
    Task<Motorcycle> GetByIdAsync(string id);

    Task<IEnumerable<Motorcycle>> GetByPlateAsync(string plate);

    Task<bool> ExistByPlateAsync(string plate);

    Task<bool> ExistById(string id);

    Task<string> GetCnhById(string id);
}
