using HRHiringSystem.Application.Abstractions.Messaging;
using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace HRHiringSystem.Application.Features.Authentication.Commands.ForgotPassword;

internal sealed class ForgotPasswordHandler : ICommandHandler<ForgotPasswordCommand, bool>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly IUrlHelper _urlHelper;

    public ForgotPasswordHandler(
        UserManager<UserEntity> userManager,
        IEmailSender emailSender,
        IUrlHelperFactory urlHelperFactory,
        IActionContextAccessor actionContextAccessor)
    {
        _userManager = userManager;
        _emailSender = emailSender;
        _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
    }

    public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return true;

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var resetLink = _urlHelper.Action("ResetPassword", "Authentication",
            new { token, email = user.Email },
            _urlHelper.ActionContext.HttpContext.Request.Scheme);

        await _emailSender.SendEmailAsync(
            user.Email,
            "Reset Password",
            $"Please reset your password by clicking here: {resetLink}");

        return true;
    }
}
