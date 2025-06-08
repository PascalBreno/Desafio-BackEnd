using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace MotosAluguel.Infra.DbContext;

public class DatabaseConnection
{
    private readonly string _connectionString;

    public DatabaseConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}
