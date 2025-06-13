using Dapper;
using Microsoft.Extensions.Configuration;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Infra.Repositories.Base;

namespace MotosAluguel.Infra.Repositories.Motorcyles;

public class MotorcyclesReaderRepository(IConfiguration configuration) 
    : BaseReadRepository(configuration), IMotorcyclesReadRepository
{
    public async Task<bool> ExistById(string id)
    {
        string sql = @"Select Count(*) from Motorcycles
                       Where Id = @Id AND IsDeleted = false;";

        using var connection = GetConnection();

        var parameters = new { Id = id };
        var result = await connection.QuerySingleOrDefaultAsync<int>(sql, parameters);

        return result > 0;
    }
    

    public async Task<bool> ExistByPlateAsync(string plate)
    {
        using var connection = GetConnection();

        const string sql = "SELECT COUNT(*) FROM Motorcycles " +
                           "WHERE Plate = @Plate AND IsDeleted = false";

        var parameters = new { Plate = plate };
        var count = await connection.QuerySingleOrDefaultAsync<int>(sql, parameters);

        return count > 0;

    }

    public async Task<Motorcycle> GetByIdAsync(string id)
    {
        string sql = @"Select * from Motorcycles
                       Where Id = @Id AND IsDeleted = false;";

        using var connection = GetConnection();

        var parameters = new { Id = id };

        var result = await connection.QuerySingleOrDefaultAsync<Motorcycle>(sql, parameters);

        return result;
    }

    public async Task<IEnumerable<Motorcycle>> GetByPlateAsync(string plate)
    {
        string sql = @"Select * from Motorcycles
                       Where Plate like @plate AND IsDeleted = false;";

        using var connection = GetConnection();

        var parameters = new { Plate = $"%{plate}%" };
        var result = await connection.QueryAsync<Motorcycle>(sql, parameters);

        return result;
    }
}
