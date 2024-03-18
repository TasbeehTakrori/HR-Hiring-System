using FluentValidation;
using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;
internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly UserManager<UserEntity> _userManager;
    public CreateUserCommandValidator(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;

        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("Name is required.");
        RuleFor(u => u.Email).NotEmpty()
            .WithMessage("Email is required.");
        RuleFor(u => u.Password).NotEmpty()
            .WithMessage("Password is required.");

        RuleFor(u => u.Email)
                  .MustAsync(BeUniqueEmail)
                  .WithMessage("Email already exists");
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        return existingUser == null;
    }
}
