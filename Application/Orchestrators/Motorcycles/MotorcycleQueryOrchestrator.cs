using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Commons.Response;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Mappers.Motorcycles;
using MotosAluguel.Application.Querys.Motorcycles;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleQueryOrchestrator : IMotorcycleQueryOrchestrator
{
    private readonly IMotorcyclesReadRepository _repository;

    public async Task<OperationResult<MotorcycleResponse>> 
        GetMotorcycleByIdAsync(string id)
    {
        var motorcycle = await _repository.GetByIdAsync(id);

        if (motorcycle == null)
        {
            return OperationResult<MotorcycleResponse>.Fail("Moto não encontrada");
        }

        var response = MotorcycleResponseMapper.ToResponse(motorcycle);

        return OperationResult<MotorcycleResponse>.Ok(response);
    }

    public async Task<OperationResult<IEnumerable<MotorcycleResponse>>> 
        GetMotorcyclesByFilter(MotorcyclesByFilterQuery filter)
    {
        var motorcycles = await _repository.GetByPlateAsync(filter.Plate);

        var response = MotorcycleResponseMapper.ToResponseList(motorcycles);

        return OperationResult<IEnumerable<MotorcycleResponse>>.Ok(response);
    }
}
