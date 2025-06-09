using Dapper;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Infra.DbContext;

namespace MotosAluguel.Infra.Repositories.Motorcyles;

public class MotorcycleWriterRepository : IMotorcycleWriterRepository
{
    private readonly DatabaseWriterConnection _dbConnection;

    public MotorcycleWriterRepository(DatabaseWriterConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    public async Task<string> InsertAsync(Motorcycle motorCycle)
    {
        string sql = @"INSERT INTO MotorCycles 
                       (Id, ""Year"", Model, Plate, CreatedAt) 
                       VALUES (@Id, @Year, @Model, @Plate, @CreatedAt)
                       RETURNING Id";

        using var connection = _dbConnection.CreateConnection();

        var result =  await connection.QuerySingleAsync<string>(sql, motorCycle);
        
        return result;
    }
}
