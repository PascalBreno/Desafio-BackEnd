using MotosAluguel.Domain.Entities.Base;

namespace MotosAluguel.Domain.Entities.Entregadores;

public sealed class Entregador : EntityBase
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Cnpj { get; set; }

    public DateTime BirthDate { get; set; }

    public string Cnh { get; set; }

    public string CnhType { get; set; }

    public string ImageCnhUrl { get; set; }
}
