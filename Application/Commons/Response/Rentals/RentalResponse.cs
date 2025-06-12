using MotosAluguel.Domain.Entities.Riders;
using System.Text.Json.Serialization;

namespace MotosAluguel.Application.Commons.Response.Rentals;

public class RentalResponse
{
    [JsonPropertyName("identificador")]
    public string Id { get; init; }

    [JsonPropertyName("valor_diaria")]
    public long ValueRental { get; init; }

    [JsonPropertyName("entregador_id")]
    public string RiderId { get; init; }

    [JsonPropertyName("moto_id")]
    public string MotorCycleId { get; init; }

    [JsonPropertyName("data_inicio")]
    public DateTime BeginAt { get; init; }

    [JsonPropertyName("data_termino")]
    public DateTime EndAt { get; init; }

    [JsonPropertyName("data_previsao_termino")]
    public DateTime EstimatedEndDate { get; init; }

    [JsonPropertyName("data_devolucao")]
    public DateTime ReceivedDate { get; set; }
}
