using Dapper;
using Microsoft.Extensions.Configuration;
using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Infra.Repositories.Base;

namespace MotosAluguel.Infra.Repositories.Riders;

public class RiderReaderRepository(IConfiguration configuration) : BaseReadRepository(configuration), IRiderReaderRepository
{
    public async Task<bool> ExistByCnh(string cnh)
    {
        string sql = @"SELECT COUNT(*) FROM Riders
                       WHERE Cnh = @Cnh;";
            
        using var connection = GetConnection();
        var parameters = new { Cnh = cnh };
        var result = await connection.QuerySingleAsync<int>(sql, parameters);

        return result > 0;
    }

    public async Task<bool> ExistByCnpj(string cnpj)
    {
        string sql = @"SELECT COUNT(*) FROM Riders
                       WHERE Cnpj = @cnpj;";

        using var connection = GetConnection();

        var parameters = new { Cnpj = cnpj };
        var result = await connection.QuerySingleAsync<int>(sql, parameters);

        return result > 0;
    }

    public async Task<bool> ExistById(string id)
    {
        string sql = @"Select Count(1) from Riders
                       Where Id = @Id;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<int>(sql, id);

        return result > 0;
    }

    public async Task<Rider> GetByIdAsync(string id)
    {
        string sql = @"Select * from Riders
                       Where Id = @Id;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<Rider>(sql, id);

        return result;
    }
}
