using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace MotosAluguel.Infra.DbContext;

public class DatabaseReaderConnection
{
    private readonly string _connectionString;

    public DatabaseReaderConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ReaderConnection");
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}
