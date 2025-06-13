using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Domain.Entities.Riders;

namespace MotosAluguel.Application.Mappers.Riders;

public class RiderMapper
{
    public static Rider ToEntity(RiderInsertCommand command)
    {
        return new Rider
        {
            Id = command.Identificador,
            Name = command.Nome,
            Cnpj = command.Cnpj,
            BirthDate = command.Data_Nascimento,
            Cnh = command.Numero_cnh,
            CnhType = command.Tipo_cnh
        };
    }
}
