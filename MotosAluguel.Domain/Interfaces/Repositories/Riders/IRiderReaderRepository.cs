using MotosAluguel.Domain.Entities.Riders;

namespace MotosAluguel.Domain.Interfaces.Repositories.Riders;

public interface IRiderReaderRepository
{
    Task<Rider> GetByIdAsync(string id);

    Task<bool> ExistByCnh(string cnh);

    Task<bool> ExistByCnpj(string cnpj);

    Task<bool> ExistById(string id);
}
