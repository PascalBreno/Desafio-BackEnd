using MotosAluguel.Domain.Entities.Rentals;

namespace MotosAluguel.Domain.Interfaces.Repositories.Rentals;

public interface IRentalReaderRepository
{
    Task<Rental> GetByIdAsync(string id);

    Task<bool> ExistById(string id);
}
