using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleUpdateOrchestrator
{
    Task<OperationResult<string>> UpdatePlateAsync(
        string id,
        MotorcycleUpdatePlateCommand command);
}
