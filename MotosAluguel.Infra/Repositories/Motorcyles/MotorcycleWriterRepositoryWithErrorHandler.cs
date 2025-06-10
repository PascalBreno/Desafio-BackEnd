using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;

namespace MotosAluguel.Infra.Repositories.Motorcyles;

public class MotorcycleWriterRepositoryWithErrorHandler : IMotorcycleWriterRepository
{
    private readonly IMotorcycleWriterRepository _motorCycleWriterRepository;

    public MotorcycleWriterRepositoryWithErrorHandler(IMotorcycleWriterRepository motorCycleWriterRepository)
    {
        _motorCycleWriterRepository = motorCycleWriterRepository;
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _motorCycleWriterRepository.DeleteAsync(id);
        }

        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting the motor cycle.", ex);
        }
    }

    public async Task<string> InsertAsync(Motorcycle motorCycle)
    {
        try
        {
            return await _motorCycleWriterRepository.InsertAsync(motorCycle);
        }

        catch (Exception ex)
        {
            throw new Exception("An error occurred while inserting the motor cycle.", ex);
        }
    }

    public Task<bool> UpdatePlateAsync(string id, string plate)
    {
        throw new NotImplementedException();
    }
}
