namespace MotosAluguel.Application.Commands.Riders;

public class RiderInsertCommand
{
    public string Identificador { get; set; }

    public string Nome { get; set; }

    public string Cnpj { get; set; }

    public DateTime Data_Nascimento { get; set; }

    public string Numero_cnh { get; set; }

    public string Tipo_cnh { get; set; }
}
