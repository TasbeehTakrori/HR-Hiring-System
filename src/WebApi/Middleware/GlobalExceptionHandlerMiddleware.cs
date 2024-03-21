using HRHiringSystem.Application.ExceptionHandling;
using HRHiringSystem.Domain.Exceptions.Base;

namespace WebApi.Middleware;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    private static Dictionary<Type, IExceptionHandler> _exceptionHandlers = new()
        {
            { typeof(NotFoundException), new NotFoundExceptionHandler() },
            { typeof(Exception), new UnhandledExceptionHandler() },
            { typeof(BadRequestException), new BadRequestExceptionHandler() }
        };

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadRequestException ex)
        {
            await _exceptionHandlers[typeof(BadRequestException)]
                .HandleAsync(context, ex);
        }
        catch (NotFoundException ex)
        {
            await _exceptionHandlers[typeof(NotFoundException)]
                .HandleAsync(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            await _exceptionHandlers[typeof(Exception)]
                .HandleAsync(context, ex);
        }
    }
}
