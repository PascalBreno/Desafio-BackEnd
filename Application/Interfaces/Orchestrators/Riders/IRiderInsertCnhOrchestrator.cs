using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Commons;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Riders;

public interface IRiderInsertCnhOrchestrator
{
    Task<OperationResult<string>> RunAsync(RiderInsertCommand command);
}
