using FluentValidation;
using HRHiringSystem.Domain.Constants;
using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;
public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly UserManager<UserEntity> _userManager;
    public CreateUserCommandValidator(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;

        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(u => u.Password).NotEmpty()
            .WithMessage("Password is required.");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email is not in a valid format.")
            .MustAsync(BeUniqueEmail)
            .WithMessage("Email already exists");


        RuleFor(u => u.PhoneNumber).NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(RegexPatterns.PhoneRegex)
            .WithMessage("Phone Number is not in a valid format.");
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        return existingUser == null;
    }
}
