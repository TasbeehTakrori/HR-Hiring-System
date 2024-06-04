using HRHiringSystem.Domain.Primitive;
using Microsoft.EntityFrameworkCore;

namespace HRHiringSystem.Persistence.Configurations;
internal class ConcurrencyConfiguration
{
    internal static void Configure(ModelBuilder modelBuilder)
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
}

