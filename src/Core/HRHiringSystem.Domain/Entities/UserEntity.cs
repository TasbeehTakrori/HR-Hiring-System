using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRHiringSystem.Domain.Entities;

public class UserEntity : IdentityUser
{
    public string DisplayName { get; set; }
}