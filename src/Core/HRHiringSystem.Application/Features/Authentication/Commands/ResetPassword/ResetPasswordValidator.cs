using FluentValidation;

namespace HRHiringSystem.Application.Features.Authentication.Commands.ResetPassword;

internal sealed class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email is not in a valid format.");

        //TODO : validate token
        RuleFor(r => r.Token)
            .NotEmpty()
            .WithMessage("Token is required.");

        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage("Password is required."); 
        
        RuleFor(r => r.ConfirmPassword)
            .NotEmpty()
            .WithMessage("ConfirmPassword is required.");  
        
        RuleFor(r => r.Password)
            .Equal(r => r.ConfirmPassword)
            .WithMessage("Password and ConfirmPassword do not match.");
    }
}
