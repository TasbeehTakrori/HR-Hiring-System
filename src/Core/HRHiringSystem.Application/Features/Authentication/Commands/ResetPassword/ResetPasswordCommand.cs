using HRHiringSystem.Application.Abstractions.Messaging;

namespace HRHiringSystem.Application.Features.Authentication.Commands.ResetPassword;

public sealed record ResetPasswordCommand(string Email, string Token, string Password, string ConfirmPassword)
    : ICommand<bool>;
