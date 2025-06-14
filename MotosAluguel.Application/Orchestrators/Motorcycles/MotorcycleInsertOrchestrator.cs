using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Mappers.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Messaging.Events;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleInsertOrchestrator(
    IMotorcyclesInsertValidator validator,
    IMotorcycleWriterRepository repository,
    ServiceBusPublisher publishEndpoint) : IMotorcycleInsertOrchestrator
{
    private readonly IMotorcyclesInsertValidator _validator = validator;

    private readonly IMotorcycleWriterRepository _repository = repository;

    private readonly ServiceBusPublisher _publishEndpoint = publishEndpoint;

    public async Task<OperationResult> RunAsync(MotorcycleInsertCommand command)
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

            await _publishEndpoint.SendMessageAsync(registeredEvent);

            var response = MotorcycleResponseMapper.ToResponse(entity);

            return OperationResult.Ok();
        }

        return operationResult;
    }

}
