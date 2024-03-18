using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HRHiringSystem.Application.ExceptionHandling;
public class NotFoundExceptionHandler : IExceptionHandler
{
    public async Task HandleAsync(HttpContext context, Exception ex)
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Title = "Resource not found",
            Detail = ex.Message
        };

        context.Response.StatusCode = StatusCodes.Status404NotFound;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }
}
