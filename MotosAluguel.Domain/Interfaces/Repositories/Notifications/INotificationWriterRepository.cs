using MotosAluguel.Domain.Entities.Notifications;

namespace MotosAluguel.Domain.Interfaces.Repositories.Notifications;

public interface INotificationWriterRepository
{
    Task<string> InsertAsync(Notification notification);
}

