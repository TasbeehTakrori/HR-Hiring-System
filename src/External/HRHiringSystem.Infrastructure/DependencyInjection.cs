using HRHiringSystem.Application.Abstractions;
using HRHiringSystem.Infrastructure.Authentication;
using HRHiringSystem.Infrastructure.Configurations;
using HRHiringSystem.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRHiringSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
      this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwtAuthentication(configuration);
        services.AddScoped<IJwtProvider, JwtProvider>();

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}

