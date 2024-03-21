namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserRequest(string Name, string Email, string Password, string PhoneNumber);
