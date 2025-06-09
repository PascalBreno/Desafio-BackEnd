using MotosAluguel.Domain.Entities.Base;

namespace MotosAluguel.Domain.Entities.MotorCycles;

public sealed class Motorcycle : EntityBase
{
    public string Id { get; init; }

    public int Year { get; init; }

    public string Model { get; init; }

    public string Plate { get; init; }
}
