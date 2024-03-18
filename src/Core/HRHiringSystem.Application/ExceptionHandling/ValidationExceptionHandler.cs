using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HRHiringSystem.Application.ExceptionHandling;

public class ValidationExceptionHandler : IExceptionHandler
{
    public async Task HandleAsync(HttpContext context, Exception ex)
    {
        var validationException = ex as FluentValidation.ValidationException;
        if (validationException != null)
        {
            var errors = validationException.Errors.Select(
                error => new { Property = error.PropertyName, Message = error.ErrorMessage })
                .ToDictionary(error => error.Property, error => new[] { error.Message });
            var problemDetails = new ValidationProblemDetails(errors)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation error",
                Detail = "One or more validation errors occurred."
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }
}

