using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRHiringSystem.Domain.Entities;

[Table("Users")]
public class UserEntity : IdentityUser
{
    public ICollection<IdentityUserRole<string>> Roles { get; } = [];
}