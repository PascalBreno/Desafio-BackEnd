using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;

namespace MotosAluguel.Infra.Repositories.Riders;

public class RiderWriterRepositoryWithErrorHandler : IRiderWriterRepository
{
    private readonly IRiderWriterRepository _riderWriterRepository;

    public RiderWriterRepositoryWithErrorHandler(IRiderWriterRepository riderWriterRepository)
    {
        _riderWriterRepository = riderWriterRepository;
    }

    public async Task<string> InsertAsync(Rider rider)
    {
        try
        {
            return await _riderWriterRepository.InsertAsync(rider);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while inserting the rider", ex);
        }
    }

    public async Task UpdateImageCnhASync(string id, string imageCnhUrl)
    {
        try
        {
            await _riderWriterRepository.UpdateImageCnhASync(id, imageCnhUrl);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while inserting the rider", ex);
        }
    }
}