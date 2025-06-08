using MotosAluguel.Domain.Entities.Base;

namespace MotosAluguel.Domain.Entities.MotorCycles;

public sealed class MotorCycle : EntityBase
{
    public string Id { get; set; }

    public int Year { get; set; }

    public string Model { get; set; }

    public string Plate { get; set; }
}
