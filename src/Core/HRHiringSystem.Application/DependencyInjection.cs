using FluentValidation;
using HRHiringSystem.Application.Behaviors;
using HRHiringSystem.Application.Features.Users.Commands.CreateUser;
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
        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

        return services;
    }
}
