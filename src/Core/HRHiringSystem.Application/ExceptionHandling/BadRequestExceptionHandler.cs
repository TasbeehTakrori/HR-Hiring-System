using HRHiringSystem.Domain.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HRHiringSystem.Application.ExceptionHandling;

public class BadRequestExceptionHandler : IExceptionHandler
{
    public async Task HandleAsync(HttpContext context, Exception ex)
    {
        var badRequestException = ex as BadRequestException;
        if (badRequestException != null)
        {
            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = "One or more validation errors occurred."
            };

            if (badRequestException.Errors != null && badRequestException.Errors.Any())
            {
                problemDetails.Extensions.Add("errors", badRequestException.Errors);
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }

}

