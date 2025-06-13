using MassTransit;
using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons.Response.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Mappers.Motorcycles;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Messaging.Events;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleInsertOrchestrator(
    IMotorcyclesInsertValidator validator,
    IMotorcycleWriterRepository repository,
    IPublishEndpoint publishEndpoint) : IMotorcycleInsertOrchestrator
{
    private readonly IMotorcyclesInsertValidator _validator = validator;

    private readonly IMotorcycleWriterRepository _repository = repository;

    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task<OperationResult<MotorcycleResponse>> RunAsync(MotorcycleInsertCommand command)
    {
        var entity = MotorcycleMapper.ToEntity(command);

        var operationResult = await _validator.ValidateAsync(entity);

        if (operationResult.Success)
        {
            await _repository.InsertAsync(entity);

            var registeredEvent = new MotorcycleRegisteredEvent
            {
                Id = entity.Id,
                Year = entity.Year,
                Model = entity.Model,
                Plate = entity.Plate
            };

            await _publishEndpoint.Publish(registeredEvent);

            var response = MotorcycleResponseMapper.ToResponse(entity);

            return OperationResult<MotorcycleResponse>.Ok(response);
        }

        return OperationResult<MotorcycleResponse>.Fail(operationResult);
    }
}
