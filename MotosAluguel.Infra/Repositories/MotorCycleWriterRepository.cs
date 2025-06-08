using MotosAluguel.Domain.Interfaces.Repositories;

namespace MotosAluguel.Infra.Repositories;

public class MotorCycleWriterRepository : IMotorCycleWriterRepository
{
    public Task<string> InsertAsync(Motorcycle motorCycle)
    {
        throw new NotImplementedException();
    }
}
