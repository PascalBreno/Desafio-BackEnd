namespace MotosAluguel.Application.Commands.Rentals;

public record class RentalMotorcycleProcessCommand
{
    public string Entregador_id { get; init; }
    public string Moto_id { get; init; }
    public DateTime Data_inicio { get; init; }
    public DateTime Data_termino { get; init; }
    public DateTime Data_previsao_termino { get; init; }
    public int Plano { get; init; }
}
