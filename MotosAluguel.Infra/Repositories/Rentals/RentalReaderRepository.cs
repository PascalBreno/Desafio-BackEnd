using Dapper;
using Microsoft.Extensions.Configuration;
using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Infra.Repositories.Base;

namespace MotosAluguel.Infra.Repositories.Rentals;

public class RentalReaderRepository(IConfiguration configuration) : BaseReadRepository(configuration), IRentalReaderRepository
{
    public Task<bool> ExistById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Rental> GetByIdAsync(string id)
    {
        string sql = @"Select * from Rentals
                       Where Id = @Id;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<Rental>(sql, id);

        return result;
    }
}
