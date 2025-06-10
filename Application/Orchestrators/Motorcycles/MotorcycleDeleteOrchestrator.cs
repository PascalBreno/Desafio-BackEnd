using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleDeleteOrchestrator : IMotorcycleDeleteOrchestrator
{
    private readonly IMotorcycleWriterRepository _repository;

    public MotorcycleDeleteOrchestrator(IMotorcycleWriterRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult<bool>> RunAsync(string id)
    {
        await _repository.DeleteAsync(id);

        return OperationResult<bool>.Ok(true);
    }
}
