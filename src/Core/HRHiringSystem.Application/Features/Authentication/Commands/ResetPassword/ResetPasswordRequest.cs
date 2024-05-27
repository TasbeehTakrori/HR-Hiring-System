using Microsoft.AspNetCore.Mvc;

namespace HRHiringSystem.Application.Features.Authentication.Commands.ResetPassword;

public sealed record ResetPasswordRequest([FromQuery] string Email, [FromQuery] string Token, [FromBody] string Password, [FromBody] string ConfirmPassword);
