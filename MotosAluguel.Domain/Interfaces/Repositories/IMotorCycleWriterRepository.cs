using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Domain.Interfaces.Repositories;

public interface IMotorCycleWriterRepository
{
    Task<string> InsertAsync(MotorCycle motorCycle);
}
