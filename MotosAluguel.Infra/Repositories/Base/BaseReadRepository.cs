using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace MotosAluguel.Infra.Repositories.Base;

public abstract class BaseReadRepository
{
    private readonly string _dbConnection;

    public BaseReadRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("ReadConnection");
    }

    protected IDbConnection GetConnection() => new NpgsqlConnection(_dbConnection);
}