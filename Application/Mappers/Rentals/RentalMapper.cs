using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Domain.Entities.Rentals;

namespace MotosAluguel.Application.Mappers.Rentals;

public class RentalMapper
{
    public static Rental ToEntity(RentalMotorcycleProcessCommand command)
    {
        return new Rental
        {
            RiderId = command.Entregador_id,
            MotorCycleId = command.Moto_id,
            BeginAt = command.Data_inicio,
            EndAt = command.Data_termino,
            EstimatedEndDate = command.Data_previsao_termino,
            Plan = command.Plano,
        };
    }
}
