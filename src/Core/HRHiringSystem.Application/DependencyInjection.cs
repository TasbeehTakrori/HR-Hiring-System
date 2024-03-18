using HRHiringSystem.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HRHiringSystem.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
