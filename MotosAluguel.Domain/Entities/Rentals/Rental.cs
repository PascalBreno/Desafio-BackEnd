using MotosAluguel.Domain.Entities.Base;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Entities.Riders;

namespace MotosAluguel.Domain.Entities.Rentals;

public sealed class Rental : EntityBase
{
    public string RiderId { get; init; }

    public Rider Rider { get; set; }

    public string MotorCycleId { get; init; }

    public Motorcycle MotorCycle { get; set; }

    public DateTime BeginAt { get; init; }

    public DateTime EndAt { get; init; }

    public DateTime EstimatedEndDate { get; init; }

    public int Plan { get; set; }
}
