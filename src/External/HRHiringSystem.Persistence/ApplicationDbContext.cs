using HRHiringSystem.Domain.Entities;
using HRHiringSystem.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRHiringSystem.Persistence;
public class ApplicationDbContext : IdentityDbContext<UserEntity, RoleEntity, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Persistence.AssemblyReference).Assembly);

        IdentityConfiguration.Configure(modelBuilder);
        SoftDeleteConfiguration.Configure(modelBuilder);
        ConcurrencyConfiguration.Configure(modelBuilder);
    }
}