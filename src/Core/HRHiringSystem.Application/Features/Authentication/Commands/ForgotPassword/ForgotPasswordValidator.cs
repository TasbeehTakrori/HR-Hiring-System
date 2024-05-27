using FluentValidation;

namespace HRHiringSystem.Application.Features.Authentication.Commands.ForgotPassword;

internal sealed class ForgotPasswordValidator : AbstractValidator<ForgotPasswordCommand> 
{
    public ForgotPasswordValidator()
    {
        RuleFor(f => f.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email is not in a valid format.");
    }
}
