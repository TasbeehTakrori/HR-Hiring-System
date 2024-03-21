using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json;

namespace HRHiringSystem.Application.Behaviors;


internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {

        var requestName = request.GetType().Name;
        var requestGuid = Guid.NewGuid().ToString();

        var requestNameWithGuid = $"{requestName} [{requestGuid}]";

        logger.LogInformation($"[START] {requestNameWithGuid}");
        TResponse response;

        var stopwatch = Stopwatch.StartNew();
        try
        {

            logger.LogInformation($"[PROPS] {requestNameWithGuid} {JsonSerializer.Serialize(request)}");
            response = await next();
        }
        catch (Exception ex)
        {
            logger.LogError($"[ERROR] {requestNameWithGuid} {ex.Message}");
            throw;
        }
        finally
        {
            stopwatch.Stop();
            logger.LogInformation(
                $"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
        }

        return response;
    }
}