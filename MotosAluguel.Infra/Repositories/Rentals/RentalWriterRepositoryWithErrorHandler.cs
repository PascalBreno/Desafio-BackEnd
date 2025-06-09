using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;

namespace MotosAluguel.Infra.Repositories.Rentals;

public class RentalWriterRepositoryWithErrorHandler : IRentalWriterRepository
{
    private readonly IRentalWriterRepository _rentalWriterRepository;

    public RentalWriterRepositoryWithErrorHandler(IRentalWriterRepository rentalWriterRepository)
    {
        _rentalWriterRepository = rentalWriterRepository;
    }

    public async Task<Guid> InsertAsync(Rental rental)
    {
        try
        {
            return await _rentalWriterRepository.InsertAsync(rental);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while inserting the rental", ex);
        }
    }
}