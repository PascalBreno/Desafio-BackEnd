using Dapper;
using MotosAluguel.Domain.Entities.Notifications;
using MotosAluguel.Domain.Interfaces.Repositories.Notifications;
using MotosAluguel.Infra.DbContext;

namespace MotosAluguel.Infra.Repositories.Notifications;

public class NotificationWriterRepository : INotificationWriterRepository
{
    private readonly DatabaseWriterConnection _dbConnection;

    public NotificationWriterRepository(DatabaseWriterConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<string> InsertAsync(Notification notification)
    {
        string sql = @"INSERT INTO Notifications 
                       (Id, Message) 
                       VALUES (@Id, @Message)
                       RETURNING Id";

        using var connection = _dbConnection.CreateConnection();

        var parameters = new
        {
            notification.Id,
            notification.Message
        };

        var result = await connection.QuerySingleAsync<string>(sql, parameters);

        return result;
    }
}
