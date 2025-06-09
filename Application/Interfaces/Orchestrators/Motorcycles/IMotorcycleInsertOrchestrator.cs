using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleInsertOrchestrator
{
    Task<OperationResult<string>> RunAsync(MotorcycleInsertCommand command);
}
