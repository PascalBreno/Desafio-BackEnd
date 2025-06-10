using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Application.Commons;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

public interface IRentalMotorcycleProcessOrchestrator
{
    Task<OperationResult<Guid>> RunAsync(RentalMotorcycleProcessCommand command);
}
