using MotosAluguel.Application.Calculators;
using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;
using MotosAluguel.Application.Mappers.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;
using MotosAluguel.Domain.Validators.Base;

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

        var operationResult = await _validator.ValidateAsync(entity);

        if(operationResult.Success)
        {
            var valueAmount = RentalPricingCalculator.CalculateRentalCost(entity);

            entity.WithTotalValue(valueAmount);

            var result = await _repository.InsertAsync(entity);

            return OperationResult<Guid>.Ok(result);
        }

        return OperationResult<Guid>.Fail(operationResult);
    }
}
