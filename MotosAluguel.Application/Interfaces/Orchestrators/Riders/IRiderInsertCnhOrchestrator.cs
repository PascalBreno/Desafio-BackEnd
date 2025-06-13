using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Riders;

public interface IRiderInsertCnhOrchestrator
{
    Task<OperationResult> RunAsync(string id, RiderInsertCnhCommand command);
}
