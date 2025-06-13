using MassTransit;
using MotosAluguel.Domain.Entities.Notifications;
using MotosAluguel.Domain.Interfaces.Repositories.Notifications;
using MotosAluguel.Domain.Messaging.Events;

namespace MotosAluguel.Domain.Messaging.Consumers;

public class MotorcycleConsumer : IConsumer<MotorcycleRegisteredEvent>
{
    private readonly INotificationWriterRepository _notificationRepository;

    public MotorcycleConsumer(INotificationWriterRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task Consume(ConsumeContext<MotorcycleRegisteredEvent> context)
    {
        var evt = context.Message;

        if (evt.Year == 2024)
        {
            var notification = new Notification
            (
                evt.Id,
                $"Moto de 2024 cadastrada: {evt.Model} - {evt.Plate}"
            );

            await _notificationRepository.InsertAsync(notification);
        }
    }
}
