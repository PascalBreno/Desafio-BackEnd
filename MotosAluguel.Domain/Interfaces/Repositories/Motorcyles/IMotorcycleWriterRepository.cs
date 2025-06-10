using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

public interface IMotorcycleWriterRepository
{
    Task DeleteAsync(string id);

    Task<string> InsertAsync(Motorcycle motorCycle);

    Task<bool> UpdatePlateAsync(string id, string plate);
}
