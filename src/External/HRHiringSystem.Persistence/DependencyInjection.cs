using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HRHiringSystem.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Environment.GetEnvironmentVariable("HRHiringSystem_DATABASE_CONNECTION_STRING")));

        services.AddIdentityCore<UserEntity>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<RoleEntity>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
