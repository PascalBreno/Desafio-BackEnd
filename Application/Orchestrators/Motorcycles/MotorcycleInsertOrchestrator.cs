using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Mappers.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleInsertOrchestrator(
    IMotorcyclesInsertValidator validator,
    IMotorcycleWriterRepository repository) : IMotorcycleInsertOrchestrator
{
    private readonly IMotorcyclesInsertValidator _validator = validator;

    private readonly IMotorcycleWriterRepository _repository = repository;

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
