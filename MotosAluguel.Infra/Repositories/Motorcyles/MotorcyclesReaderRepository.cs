using Dapper;
using Microsoft.Extensions.Configuration;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Infra.Repositories.Base;

namespace MotosAluguel.Infra.Repositories.Motorcyles;

public class MotorcyclesReaderRepository(IConfiguration configuration) : BaseReadRepository(configuration), IMotorcyclesReadRepository
{
    public Task<bool> ExistById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistByPlateAsync(string plate)
    {
        using var connection = GetConnection();

        const string sql = "SELECT COUNT(1) FROM Motorcycles WHERE Plate = @Plate";

        var count = await connection.ExecuteScalarAsync<int>(sql, new { Plate = plate });

        return count > 0;

    }

    public async Task<Motorcycle> GetByIdAsync(string id)
    {
        string sql = @"Select * from Motorcycles
                       Where Id = @Id;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<Motorcycle>(sql, id);

        return result;
    }

    public async Task<string> GetCnhById(string id)
    {
        string sql = @"Select Cnh from Motorcycles
                       Where Id = @Id;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<string>(sql, id);

        return result;
    }
}
