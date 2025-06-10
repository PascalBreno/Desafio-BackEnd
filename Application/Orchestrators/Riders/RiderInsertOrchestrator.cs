using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Riders;
using MotosAluguel.Application.Mappers.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;

namespace MotosAluguel.Application.Orchestrators.Riders;

public class RiderInsertOrchestrator : IRiderInsertOrchestrator
{
    private readonly IRiderInsertValidator _validator;

    private readonly IRiderWriterRepository _repository;

    public RiderInsertOrchestrator(
        IRiderInsertValidator validator,
        IRiderWriterRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<OperationResult<string>> RunAsync(RiderInsertCommand command)
    {
        var entity = RiderMapper.ToEntity(command);

        var isValid = await _validator.ValidateAsync(entity);

        if (isValid)
        {
            var result = await _repository.InsertAsync(entity);

            return OperationResult<string>.Ok(result);
        }

        return OperationResult<string>.Fail("Dados inválidos");
    }
}
