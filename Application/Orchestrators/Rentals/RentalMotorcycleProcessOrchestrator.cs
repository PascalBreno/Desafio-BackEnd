using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;
using MotosAluguel.Application.Mappers.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;

namespace MotosAluguel.Application.Orchestrators.Rentals;

public class RentalMotorcycleProcessOrchestrator : IRentalMotorcycleProcessOrchestrator
{

    private readonly IRentalValidator _validator;
    private readonly IRentalWriterRepository _repository;

    public RentalMotorcycleProcessOrchestrator(
        IRentalValidator validator,
        IRentalWriterRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<OperationResult<Guid>> RunAsync(RentalMotorcycleProcessCommand command)
    {
        var entity = RentalMapper.ToEntity(command);

        var isValid = await _validator.ValidateAsync(entity);

        if( isValid )
        {
            var result = await _repository.InsertAsync(entity);
            return OperationResult<Guid>.Ok(result);
        }

        return OperationResult<Guid>.Fail("Dados inválidos para o processo de locação");
    }
}
