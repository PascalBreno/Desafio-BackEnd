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
        string sql = @"INSERT INTO Rentals 
                     (RiderId, MotorCycleId, BeginAt, EndAt, EstimatedEndDate, Plan, ValueRental)
                     VALUES (@RiderId, @MotorCycleId, @BeginAt, @EndAt, @EstimatedEndDate, @Plan, @Value)
                     RETURNING Id;";

        using var connection = _dbConnection.CreateConnection();
        
        var parameters = new
        {
            rental.RiderId,
            rental.MotorCycleId,
            rental.BeginAt,
            rental.EndAt,
            rental.EstimatedEndDate,
            rental.Plan,
            rental.Value
        };

        var result = await connection.QuerySingleAsync<Guid>(sql, parameters);

        return result;
    }
}
