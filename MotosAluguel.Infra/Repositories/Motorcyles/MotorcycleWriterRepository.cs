using Dapper;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Infra.DbContext;
using Npgsql;

namespace MotosAluguel.Infra.Repositories.Motorcyles;

public class MotorcycleWriterRepository : IMotorcycleWriterRepository
{
    private readonly DatabaseWriterConnection _dbConnection;

    public MotorcycleWriterRepository(DatabaseWriterConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
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

    public async Task<bool> UpdatePlateAsync(string id, string plate)
    {
        const string sql = @"UPDATE MotorCycles
                            SET Plate = @Plate,
                                UpdatedAt = CURRENT_TIMESTAMP
                            WHERE Id = @Id AND IsDeleted = FALSE";

        var parameters = new { Id = id, Plate = plate };

        using var connection = _dbConnection.CreateConnection();

        var rowsAffected = await connection.ExecuteAsync(sql, parameters);

        return rowsAffected > 0;
    }
}
