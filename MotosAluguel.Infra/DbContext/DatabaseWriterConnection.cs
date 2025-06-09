using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace MotosAluguel.Infra.DbContext;

public class DatabaseWriterConnection
{
    private readonly string _connectionString;

    public DatabaseWriterConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("WriterConnection");
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}
