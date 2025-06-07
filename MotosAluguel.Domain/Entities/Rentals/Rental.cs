using MotosAluguel.Domain.Entities.Base;

namespace MotosAluguel.Domain.Entities.Locacoes;

public sealed class Rental : EntityBase
{
    public string RiderId { get; init; }
    public string MotorCycleId { get; init; }
    public DateTime BeginAt { get; init; }
    public DateTime EndAt { get; init; }
    public DateTime EstimatedEndDate { get; init; }
    public int Plan { get; set; }
}
