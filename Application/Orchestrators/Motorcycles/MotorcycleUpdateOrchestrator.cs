using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Commons.Response;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Mappers.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleUpdateOrchestrator : IMotorcycleUpdateOrchestrator
{
    private readonly IMotorcycleWriterRepository _motorcycleWriterRepository;

    public MotorcycleUpdateOrchestrator(IMotorcycleWriterRepository motorcycleWriterRepository)
    {
        _motorcycleWriterRepository = motorcycleWriterRepository;
    }

    public async Task<OperationResult<MotorcycleResponse>> UpdatePlateAsync(
        string id,
        MotorcycleUpdatePlateCommand command)
    {
        var motorcycle = await _motorcycleWriterRepository.UpdatePlateAsync(id, command.Plate);
        
        var response = MotorcycleResponseMapper.ToResponse(motorcycle);

        return OperationResult<MotorcycleResponse>.Ok(response);
    }
}
