using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

public interface IMotorcycleWriterRepository
{
    Task<string> InsertAsync(Motorcycle motorCycle);
}
