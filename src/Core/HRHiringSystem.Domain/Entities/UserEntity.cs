using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Domain.Entities;
public class UserEntity : IdentityUser
{
    public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
}