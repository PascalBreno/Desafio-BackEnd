using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

public interface IRentalSettlementOrchestrator
{
    Task<OperationResult<string>> RunAsync(RentalSettlementCommand command);
}
