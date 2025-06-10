using MotosAluguel.Application.Commons;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleDeleteOrchestrator
{
    Task<OperationResult<bool>> RunAsync(string id);
}
