namespace MotosAluguel.Application.Commons.Response;

public record class MotorcycleResponse(
    string Identificador,
    int Year,
    string Modelo,
    string Placa
);
