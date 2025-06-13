namespace MotosAluguel.Domain.Messaging.Events;

public class MotorcycleRegisteredEvent
{
    public string Id { get; init; }

    public int Year { get; init; }

    public string Model { get; init; }

    public string Plate { get; init; }
}
