using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Riders;

public interface IRiderInsertOrchestrator
{
    Task<OperationResult> RunAsync(RiderInsertCommand command);
}
