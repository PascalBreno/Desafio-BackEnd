using Dapper;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories;
using MotosAluguel.Infra.DbContext;

namespace MotosAluguel.Infra.Repositories;

public class MotorCycleWriterRepository : IMotorCycleWriterRepository
{
    private readonly DatabaseConnection _dbConnection;

    public MotorCycleWriterRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    public async Task<string> InsertAsync(MotorCycle motorCycle)
    {
        string sql = @"INSERT INTO MotorCycles (Id, ""Year"", Model, Plate, CreatedAt, UpdatedAt, DeletedAt, IsDeleted) 
                       VALUES (@Id, @Year, @Model, @Plate, @CreatedAt, @UpdatedAt, @DeletedAt, @IsDeleted)
                       RETURNING Id";

        string result = string.Empty;
        try
        {
            using var connection = _dbConnection.CreateConnection();

            result =  await connection.QuerySingleAsync<string>(sql, motorCycle);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return result;
    }
}
