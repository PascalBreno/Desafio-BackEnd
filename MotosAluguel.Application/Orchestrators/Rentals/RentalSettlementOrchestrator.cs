using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Orchestrators.Rentals;

public class RentalSettlementOrchestrator : IRentalSettlementOrchestrator
{
    public Task<OperationResult> RunAsync(string id, RentalSettlementCommand command)
    {
        throw new NotImplementedException();
    }
}
