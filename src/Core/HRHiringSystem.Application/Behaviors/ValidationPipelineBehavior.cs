using FluentValidation;
using HRHiringSystem.Application.Abstractions.Messaging;
using HRHiringSystem.Domain.Exceptions.Base;
using MediatR;

namespace HRHiringSystem.Application.Behaviors;

public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationTasks = _validators.Select(v => v.ValidateAsync(context, cancellationToken));
        var validationResults = await Task.WhenAll(validationTasks);

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Select(e => new { Property = e.PropertyName, Message = e.ErrorMessage })
            .ToDictionary(error => error.Property, error => new[] { error.Message });

        if (failures.Any())
            throw new BadRequestException(failures);

        return await next();
    }
}