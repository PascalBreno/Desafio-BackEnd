using MotosAluguel.Domain.Entities.Base;

namespace MotosAluguel.Domain.Entities.Riders;

public sealed class Rider : EntityBase
{
    public string Id { get; init; }

    public string Name { get; init; }

    public string Cnpj { get; init; }

    public DateTime BirthDate { get; init; }

    public string Cnh { get; init; }

    public string CnhType { get; init; }

    public string ImageCnhUrl { get; init; }

    public string ImagemCnhbase64 { get; private set; }

    public void WithImageUrl(string imageUrl)
    {
        ImagemCnhbase64 = imageUrl;
    }
}
