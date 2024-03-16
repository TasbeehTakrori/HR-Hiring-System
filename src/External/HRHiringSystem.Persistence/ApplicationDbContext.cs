using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRHiringSystem.Persistence;
public class ApplicationDbContext : IdentityDbContext<UserEntity>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var softDeleteEntities = typeof(ISoftDelete).Assembly.GetTypes()
                  .Where(type => typeof(ISoftDelete)
                                  .IsAssignableFrom(type)
                                  && type.IsClass
                                  && !type.IsAbstract);

        foreach (var softDeleteEntity in softDeleteEntities)
        {
            modelBuilder.Entity(softDeleteEntity).HasQueryFilter(
                  GenerateQueryFilterLambda(softDeleteEntity));

             modelBuilder.Entity(softDeleteEntity)
                .HasIndex("IsDeleted")
                .HasFilter("IsDeleted = 0");
        }
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