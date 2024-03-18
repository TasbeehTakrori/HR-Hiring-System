using HRHiringSystem.Application.Abstractions.Messaging;

namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;
public sealed record CreateUserCommand(string Name, string Email, string Password) : ICommand<string>;
