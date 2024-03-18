using Microsoft.Extensions.DependencyInjection;

namespace HRHiringSystem.Presentation;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}
