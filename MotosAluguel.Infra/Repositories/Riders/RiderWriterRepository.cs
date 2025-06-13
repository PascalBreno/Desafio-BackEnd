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
                       (Id, Name, Cnpj, BirthDate, Cnh, CnhType, ImageCnh)
                       VALUES (@Id, @Name, @Cnpj, @BirthDate, @Cnh, @CnhType, @ImageCnh)
                       RETURNING Id";

        using var connection = _dbConnection.CreateConnection();

        var parameters = new
        {
            rider.Id,
            rider.Name,
            rider.Cnpj,
            rider.BirthDate,
            rider.Cnh,
            rider.CnhType,
            ImageCnh = rider.ImageCnhUrl
        };

        var result = await connection.QuerySingleAsync<string>(sql, parameters);

        return result;

    }

    public async Task UpdateImageCnhASync(string id, string imageCnhUrl)
    {
        string sql = @"UPDATE Riders 
                       SET ImageCnh = @ImageCnh,
                        UpdatedAt = CURRENT_TIMESTAMP
                       WHERE Id = @Id;";

        using var connection = _dbConnection.CreateConnection();

        var parameters = new
        {
            Id = id,
            ImageCnh = imageCnhUrl
        };

        await connection.ExecuteAsync(sql, parameters);
    }
}
