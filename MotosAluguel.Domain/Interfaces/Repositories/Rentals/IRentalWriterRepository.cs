using MotosAluguel.Domain.Entities.Rentals;

namespace MotosAluguel.Domain.Interfaces.Repositories.Rentals;

public interface IRentalWriterRepository
{
    Task<Guid> InsertAsync(Rental rental);
}
