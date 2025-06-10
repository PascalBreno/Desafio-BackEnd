using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Application.Commons;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

public interface IRentalSettlementOrchestrator
{
    Task<OperationResult<string>> RunAsync(RentalSettlementCommand command);
}
