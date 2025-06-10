using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

namespace MotosAluguel.Application.Orchestrators.Rentals;

public class RentalSettlementOrchestrator : IRentalSettlementOrchestrator
{
    public Task<OperationResult<string>> RunAsync(RentalSettlementCommand command)
    {
        throw new NotImplementedException();
    }
}
