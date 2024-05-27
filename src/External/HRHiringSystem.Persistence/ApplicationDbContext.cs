using HRHiringSystem.Domain.Entities;
using HRHiringSystem.Persistence.Configurations;
using HRHiringSystem.Persistence.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRHiringSystem.Persistence;
public class ApplicationDbContext : IdentityDbContext<UserEntity, RoleEntity, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLoggerFactory(
            LoggerFactory
            .Create(builder => builder.AddConsole()
            .SetMinimumLevel(LogLevel.Warning)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Persistence.AssemblyReference).Assembly);

        IdentityConfiguration.Configure(modelBuilder);
        SoftDeleteConfiguration.Configure(modelBuilder);
        ConcurrencyConfiguration.Configure(modelBuilder);

        DbSeeder.SeedRoles(modelBuilder);
    }
}