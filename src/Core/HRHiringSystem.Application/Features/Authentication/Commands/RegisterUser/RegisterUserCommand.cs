using HRHiringSystem.Application.Abstractions.Messaging;

namespace HRHiringSystem.Application.Features.Authentication.Commands.RegisterUser;
public sealed record RegisterUserCommand(string Name, string Email, string Password, string PhoneNumber, string Role)
    : ICommand<string>;
