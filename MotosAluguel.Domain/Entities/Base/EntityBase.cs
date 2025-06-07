namespace MotosAluguel.Domain.Entities.Base;

public abstract class EntityBase
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}
