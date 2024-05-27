using HRHiringSystem.Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Authentication.Commands.ForgotPassword;
public sealed record ForgotPasswordCommand(string Email) : ICommand<bool>;
