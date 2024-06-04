using System.ComponentModel.DataAnnotations;

namespace HRHiringSystem.Domain.Primitive;
public interface IBaseEntity
{
    public int Id { get; set; }

    [Timestamp]
    public byte[] Timestamp { get; set; }
}
