using MotosAluguel.Application.Commons.Response;
using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Application.Mappers.Motorcycles;

public class MotorcycleResponseMapper
{
    public static MotorcycleResponse ToResponse(Motorcycle motorcycle)
    {
        return new MotorcycleResponse(
            motorcycle.Id,
            motorcycle.Year,
            motorcycle.Model,
            motorcycle.Plate
        );
    }

    public static IEnumerable<MotorcycleResponse> ToResponseList(IEnumerable<Motorcycle> motorcycles)
    {
        return [.. motorcycles.Select(ToResponse)];
    }
}
