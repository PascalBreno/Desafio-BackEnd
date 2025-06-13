using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Domain.Entities.MotorCycles;

namespace MotosAluguel.Application.Mappers.Motorcycles;

public static class MotorcycleMapper
{
    public static Motorcycle ToEntity(MotorcycleInsertCommand command)
    {
        return new Motorcycle
        {
            Id = command.Identificador,
            Plate = command.Placa,
            Model = command.Modelo,
            Year = command.Ano
        };
    }

}

