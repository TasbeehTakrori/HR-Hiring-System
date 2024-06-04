namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;

public sealed record RegisterUserRequest(string Name, string Email, string Password, string PhoneNumber, string Role);
