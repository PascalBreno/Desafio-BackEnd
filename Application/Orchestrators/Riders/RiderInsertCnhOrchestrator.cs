using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Interfaces.Orchestrators.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.StorageManager;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Orchestrators.Riders;

public class RiderInsertCnhOrchestrator : IRiderInsertCnhOrchestrator
{
    private readonly IRiderUpdateCnhValidator _validator;
    private readonly IRiderWriterRepository _repository;
    private readonly ILocalStorageService _localStorageService;
    public RiderInsertCnhOrchestrator(
        IRiderUpdateCnhValidator validator,
        IRiderWriterRepository repository,
        ILocalStorageService localStorageService)
    {
        _validator = validator;
        _repository = repository;
        _localStorageService = localStorageService;
    }

    public async Task<OperationResult> RunAsync(string id, RiderInsertCnhCommand command)
    {
        var operationResult = await _validator.ValidateAsync(id, command.Imagem_cnh);

        if(operationResult.Success)
        {
            var imageUrl = await _localStorageService.SaveBase64ImageAsync(command.Imagem_cnh);

            await _repository.UpdateImageCnhASync(id, imageUrl);
        }

        return operationResult;
    }
}
