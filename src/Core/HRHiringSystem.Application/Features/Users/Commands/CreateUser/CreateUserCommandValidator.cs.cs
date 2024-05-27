using FluentValidation;
using HRHiringSystem.Domain.Constants;
using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;

internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly UserManager<UserEntity> _userManager;

    public CreateUserCommandValidator(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
        // TODO => Check the email domain
        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("Password is required.");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email is not in a valid format.")
            .MustAsync(BeUniqueEmail)
            .WithMessage("Email already exists");

        RuleFor(u => u.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(RegexPatterns.PhoneRegex)
            .WithMessage("Phone Number is not in a valid format.");

        RuleFor(u => u.Role)
            .NotEmpty()
            .WithMessage("UserRole is required.");

        RuleFor(u => u.Role)
           .Must(BeValidRole)
           .When(u => !string.IsNullOrEmpty(u.Role))
           .WithMessage("UserRole is Invalid.");
    }

    private bool BeValidRole(string role)
    {
        var validRoles = new[] { Roles.Recruiter, Roles.Interviewer, Roles.HRManager };

        return validRoles.Contains(role);
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return await _userManager.FindByEmailAsync(email ?? string.Empty) == null;
    }
}
