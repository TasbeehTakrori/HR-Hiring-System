using HRHiringSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRHiringSystem.Persistence.Configurations;
internal class SoftDeleteConfiguration
{
    internal static void Configure(ModelBuilder modelBuilder)
    {
        var applicationEntities = typeof(ISoftDelete).Assembly.GetTypes()
                .Where(type => typeof(ISoftDelete)
                                .IsAssignableFrom(type)
                                && type.IsClass
                                && !type.IsAbstract);

        foreach (var entity in applicationEntities)
        {
            ConfigureSoftDeleteQueryFilter(modelBuilder, entity);
            ConfigureSoftDeleteIndex(modelBuilder, entity);
        }
    }

    private static void ConfigureSoftDeleteQueryFilter(ModelBuilder modelBuilder, Type entity)
    {
        var parameter = Expression.Parameter(entity, "e");
        var falseConstantValue = Expression.Constant(false);
        var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));
        var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);
        var lambda = Expression.Lambda(equalExpression, parameter);

        modelBuilder.Entity(entity).HasQueryFilter(lambda);
    }

    private static void ConfigureSoftDeleteIndex(ModelBuilder modelBuilder, Type entity)
    {
        modelBuilder.Entity(entity)
            .HasIndex(nameof(ISoftDelete.IsDeleted))
            .HasFilter($"{nameof(ISoftDelete.IsDeleted)} = 0");
    }
}
