namespace HRHiringSystem.Application.Features.Authentication.Commands.RegisterUser;

public sealed record RegisterUserRequest(string Name, string Email, string Password, string PhoneNumber, string Role);
