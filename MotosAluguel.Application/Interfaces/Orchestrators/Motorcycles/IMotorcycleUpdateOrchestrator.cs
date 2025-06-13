using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleUpdateOrchestrator
{
    Task<OperationResult<string>> UpdatePlateAsync(
        string id,
        MotorcycleUpdatePlateCommand command);
}
