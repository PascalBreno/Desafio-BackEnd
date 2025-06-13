using MassTransit;
using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons.Response.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Mappers.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Messaging.Events;
using MotosAluguel.Domain.Validators.Base;
using Serilog;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleInsertOrchestrator(
    IMotorcyclesInsertValidator validator,
    IMotorcycleWriterRepository repository,
    IPublishEndpoint publishEndpoint,
    ILogger logger) : IMotorcycleInsertOrchestrator
{
    private readonly IMotorcyclesInsertValidator _validator = validator;

    private readonly IMotorcycleWriterRepository _repository = repository;

    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    private readonly ILogger _logger = logger;

    public async Task<OperationResult<MotorcycleResponse>> RunAsync(MotorcycleInsertCommand command)
    {
        _logger.Information("Iiciando o processo de inserção de motocicleta com os dados: {@Command}", command);

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

            try
            {
                await _publishEndpoint.Publish(registeredEvent);

                _logger.Information("Evento de motocicleta registrada publicado com sucesso: {@Event}", registeredEvent);
            }
            catch(Exception ex)
            {
                _logger.Error("Erro ao inserir o serviço de mensageria", ex);
            }

            var response = MotorcycleResponseMapper.ToResponse(entity);

            _logger.Information("Moto inserida com sucesso: {@Response}", response);

            return OperationResult<MotorcycleResponse>.Ok(response);
        }

        return OperationResult<MotorcycleResponse>.Fail(operationResult);
    }
}
