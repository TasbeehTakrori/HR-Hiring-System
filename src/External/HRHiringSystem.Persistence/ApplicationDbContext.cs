using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRHiringSystem.Persistence;
public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureIdentityRelationships(modelBuilder);
        ConfigureSoftDeleteFilteringAndIndexes(modelBuilder);
        ConfigureTimestampsAsRowVersion(modelBuilder);
    }

    private void ConfigureSoftDeleteFilteringAndIndexes(ModelBuilder modelBuilder)
    {
        var applicationEntities = typeof(ISoftDelete).Assembly.GetTypes()
                  .Where(type => typeof(ISoftDelete)
                                  .IsAssignableFrom(type)
                                  && type.IsClass
                                  && !type.IsAbstract);

        foreach (var entity in applicationEntities)
        {
            modelBuilder.Entity(entity).HasQueryFilter(
                  GenerateQueryFilterLambda(entity));

            modelBuilder.Entity(entity)
               .HasIndex("IsDeleted")
               .HasFilter("IsDeleted = 0");
        }
    }

    private void ConfigureTimestampsAsRowVersion(ModelBuilder modelBuilder)
    {
        var applicationEntities = typeof(IBaseEntity).Assembly.GetTypes()
                  .Where(type => typeof(IBaseEntity)
                                  .IsAssignableFrom(type)
                                  && type.IsClass
                                  && !type.IsAbstract);

        foreach (var entity in applicationEntities)
        {
            var timestampProperty = entity.GetProperty("Timestamp");
            if (timestampProperty != null && timestampProperty.PropertyType == typeof(byte[]))
            {
                modelBuilder.Entity(entity)
                    .Property("Timestamp")
                    .IsRowVersion();
            }
        }
    }

    private static void ConfigureIdentityRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.Roles)
            .WithOne()
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
    }

    private LambdaExpression? GenerateQueryFilterLambda(Type type)
    {
        var parameter = Expression.Parameter(type, "e");
        var falseConstantValue = Expression.Constant(false);
        var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));
        var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);
        var lambda = Expression.Lambda(equalExpression, parameter);

        return lambda;
    }
}