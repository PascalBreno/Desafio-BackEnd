using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleDeleteOrchestrator : IMotorcycleDeleteOrchestrator
{
    private readonly IMotorcycleWriterRepository _repository;

    private readonly IMotorcycleDeleteValidator _validator;

    public MotorcycleDeleteOrchestrator(
        IMotorcycleWriterRepository repository,
        IMotorcycleDeleteValidator motorcycleDeleteValidator)
    {
        _repository = repository;
        _validator = motorcycleDeleteValidator;
    }

    public async Task<OperationResult<bool>> RunAsync(string id)
    {
        var isValid = await _validator.ValidateAsync(id);

        if (isValid)
        {
            var resultValid = await _repository.DeleteAsync(id);

            if(resultValid)
                return OperationResult<bool>.Ok();
        }

        return OperationResult<bool>.Fail("Dados inválidos");
    }
}
