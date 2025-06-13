using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Interfaces.Orchestrators.Riders;
using MotosAluguel.Application.Mappers.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.StorageManager;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Orchestrators.Riders;

public class RiderInsertOrchestrator : IRiderInsertOrchestrator
{
    private readonly IRiderInsertValidator _validator;

    private readonly IRiderWriterRepository _repository;

    private readonly ILocalStorageService _localStorageService;
    public RiderInsertOrchestrator(
        IRiderInsertValidator validator,
        IRiderWriterRepository repository,
        ILocalStorageService localStorageService)
    {
        _validator = validator;
        _repository = repository;
        _localStorageService = localStorageService;
    }

    public async Task<OperationResult> RunAsync(RiderInsertCommand command)
    {
        var entity = RiderMapper.ToEntity(command);

        var operationResult = await _validator.ValidateAsync(entity);

        if (operationResult.Success)
        {
            var imageUrl = await _localStorageService.SaveBase64ImageAsync(command.Imagem_cnh);

            entity.WithImageUrl(imageUrl);

            await _repository.InsertAsync(entity);
        }

        return operationResult;
    }
}
