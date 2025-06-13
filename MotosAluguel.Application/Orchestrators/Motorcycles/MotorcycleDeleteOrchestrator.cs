using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

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

    public async Task<OperationResult> RunAsync(string id)
    {
        var operationResult = await _validator.ValidateAsync(id);

        if (operationResult.Success)
        {
            var resultValid = await _repository.DeleteAsync(id);

            if (resultValid)
                return operationResult;

            return OperationResult.Fail("Houve um erro na inserção dos dados");
        }

        return operationResult;
    }
}
