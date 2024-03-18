using Microsoft.AspNetCore.Http;

namespace HRHiringSystem.Application.ExceptionHandling;

public interface IExceptionHandler
{
    Task HandleAsync(HttpContext context, Exception ex);
}