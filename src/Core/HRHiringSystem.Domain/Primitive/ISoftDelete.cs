namespace HRHiringSystem.Domain.Primitive;
public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}
