using Dapper;
using Microsoft.Extensions.Configuration;
using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Infra.Repositories.Base;

namespace MotosAluguel.Infra.Repositories.Riders;

public class RiderReaderRepository(IConfiguration configuration) : BaseReadRepository(configuration), IRiderReaderRepository
{
    public Task<bool> ExistByCnh(string cnh)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistByCnpj(string cnpj)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistById(string id)
    {
        throw new NotImplementedException();
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
