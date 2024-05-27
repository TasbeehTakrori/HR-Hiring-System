using HRHiringSystem.Domain.Constants;
using HRHiringSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRHiringSystem.Persistence.Seeding;
internal static class DbSeeder
{
    public static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoleEntity>().HasData(
             new RoleEntity
             {
                 Name = Roles.Recruiter,
                 NormalizedName = Roles.Recruiter.ToUpper()
             },
             new RoleEntity
             {
                 Name = Roles.Interviewer,
                 NormalizedName = Roles.Interviewer.ToUpper()
             },
             new RoleEntity
             {
                 Name = Roles.HRManager,
                 NormalizedName = Roles.HRManager.ToUpper()
             });
    }
}
