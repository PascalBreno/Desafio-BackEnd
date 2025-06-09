using MotosAluguel.Domain.Entities.Riders;

namespace MotosAluguel.Domain.Interfaces.Repositories.Riders;

public interface IRiderWriterRepository
{
    Task<string> InsertAsync(Rider rider);
}
