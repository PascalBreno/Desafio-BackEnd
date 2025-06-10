using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Commons.Response;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleUpdateOrchestrator
{
    Task<OperationResult<MotorcycleResponse>> UpdatePlateAsync(
        string id,
        MotorcycleUpdatePlateCommand command);
}
