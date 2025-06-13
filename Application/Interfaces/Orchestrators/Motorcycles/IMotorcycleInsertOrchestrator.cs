using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons.Response.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleInsertOrchestrator
{
    Task<OperationResult<MotorcycleResponse>> RunAsync(MotorcycleInsertCommand command);
}
