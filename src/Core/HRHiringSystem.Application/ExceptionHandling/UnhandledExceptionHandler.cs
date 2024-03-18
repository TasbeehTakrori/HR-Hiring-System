using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HRHiringSystem.Application.ExceptionHandling;

public class UnhandledExceptionHandler : IExceptionHandler
{
    public async Task HandleAsync(HttpContext context, Exception ex)
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal server error",
            Detail = "An unexpected error occurred while processing your request."
        };

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }
}
