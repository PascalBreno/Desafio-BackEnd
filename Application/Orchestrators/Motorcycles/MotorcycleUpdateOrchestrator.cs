using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleUpdateOrchestrator : IMotorcycleUpdateOrchestrator
{
    private readonly IMotorcycleWriterRepository _motorcycleWriterRepository;

    public MotorcycleUpdateOrchestrator(IMotorcycleWriterRepository motorcycleWriterRepository)
    {
        _motorcycleWriterRepository = motorcycleWriterRepository;
    }

    public async Task<OperationResult<string>> UpdatePlateAsync(
        string id,
        MotorcycleUpdatePlateCommand command)
    {
        if( await _motorcycleWriterRepository.UpdatePlateAsync(id, command.Plate))

            return OperationResult<string>.Ok("Placa modificada com sucesso");

        else
            return OperationResult<string>.Fail("Falha ao modificar placa");
    }
}
