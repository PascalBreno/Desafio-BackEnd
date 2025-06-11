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
        string sql = @"Select top 1 Count(*) from Riders
                       Where Cnh = @Cnh;";
            
        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<int>(sql, cnh);

        return result > 0;
    }

    public async Task<bool> ExistByCnpj(string cnpj)
    {
        string sql = @"Select top 1 Count(1) from Riders
                       Where Cnpj = @cnpj;";

        using var connection = GetConnection();

        var result = await connection.QuerySingleAsync<int>(sql, cnpj);

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
