using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Mappers.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

namespace MotosAluguel.Application.Services.Motorcycles;

public class MotorcycleInsertOrchestrator : IMotorcycleInsertOrchestrator
{
    private readonly IMotorcyclesInsertValidator _validator;

    private readonly IMotorcycleWriterRepository _repository;

    public MotorcycleInsertOrchestrator(IMotorcyclesInsertValidator validator, IMotorcycleWriterRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<OperationResult<string>> RunAsync(MotorcycleInsertCommand command)
    {
        var entity = MotorcycleMapper.ToEntity(command);

        var isValid = await _validator.ValidateAsync(entity);

        if (isValid)
        {
            var result = await _repository.InsertAsync(entity);

            return OperationResult<string>.Ok(result);
        }

        return OperationResult<string>.Fail("Dados inválidos");
    }
}
