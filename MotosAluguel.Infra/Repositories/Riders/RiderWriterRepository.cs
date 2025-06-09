using Dapper;
using MotosAluguel.Domain.Entities.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Infra.DbContext;

namespace MotosAluguel.Infra.Repositories.Riders;

public class RiderWriterRepository : IRiderWriterRepository
{
    private readonly DatabaseWriterConnection _dbConnection;

    public RiderWriterRepository(DatabaseWriterConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<string> InsertAsync(Rider rider)
    {
        string sql = @"INSERT INTO Riders 
                       (Id, Name, Cnpj, BirthDate, Cnh, CnhType)
                       VALUES (@Id, @Name, @Cnpj, @BirthDate, @Cnh, @CnhType);
                       RETURNING Id";

        using var connection = _dbConnection.CreateConnection();

        var result = await connection.QuerySingleAsync<string>(sql, rider);

        return result;

    }
}
