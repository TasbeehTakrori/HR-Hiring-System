using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Domain.Entities;

public class RoleEntity : IdentityRole
{
    public ICollection<UserEntity> Users { get; set; } = [];
}
