using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Commons;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Riders;

public interface IRiderInsertOrchestrator
{
    Task<OperationResult<string>> RunAsync(RiderInsertCommand command);
}
