using Dapper;
using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Infra.DbContext;

namespace MotosAluguel.Infra.Repositories.Rentals;

public class RentalWriterRepository : IRentalWriterRepository
{
    private readonly DatabaseWriterConnection _dbConnection;

    public RentalWriterRepository(DatabaseWriterConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Guid> InsertAsync(Rental rental)
    {
        string sql = @"INSERT INTO Rental 
                     (RiderId, MotorCycleId, BeginAt, EndAt, EstimatedEndDate, Plan)
                     VALUES (@RiderId, @MotorCycleId, @BeginAt, @EndAt, @EstimatedEndDate, @Plan)
                     RETURNING Id;";

        using var connection = _dbConnection.CreateConnection();

        var result = await connection.QuerySingleAsync<Guid>(sql, rental);

        return result;
    }
}
