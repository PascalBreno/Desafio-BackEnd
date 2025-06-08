using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Domain.Interfaces.Repositories;

public interface IMotorCycleReadRepository
{
    Task<Motorcycle> GetByIdAsync(string id);
}
