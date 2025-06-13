using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleDeleteOrchestrator
{
    Task<OperationResult> RunAsync(string id);
}
