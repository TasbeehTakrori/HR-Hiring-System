using System.ComponentModel.DataAnnotations;

namespace HRHiringSystem.Domain.Entities;
public interface IBaseEntity
{
    public int Id { get; set; }

    [Timestamp]
    public byte[] Timestamp { get; set; }
}
