using Dapper;
using Microsoft.Extensions.Configuration;
using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Infra.Repositories.Base;

namespace MotosAluguel.Infra.Repositories.Rentals;

public class RentalReaderRepository(IConfiguration configuration) : BaseReadRepository(configuration), IRentalReaderRepository
{
    public async Task<bool> ExistAnyRentalByMotorcycleId(string motorcycleId)
    {
        string sql = @"Select Count(*) from Rentals
                       Where MotorcycleId = @Id AND IsDeleted = false;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<int>(sql, new {Id = motorcycleId });

        return result > 0;
    }

    public async Task<bool> ExistById(string id)
    {
        string sql = @"Select Count(*) from Rentals
                       Where Id = @Id AND IsDeleted = false;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<int>(sql, id);

        return result > 0;
    }
    

    public async Task<Rental> GetByIdAsync(string id)
    {
        string sql = @"Select * from Rentals
                       Where Id = @Id AND IsDeleted = false;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<Rental>(sql, id);

        return result;
    }
}
