namespace MotosAluguel.Application.Commands.Rentals;

public record class RentalSettlementCommand
{
    public DateTime Data_devolucao { get; set; }
}
