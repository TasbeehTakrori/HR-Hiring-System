using HRHiringSystem.Application.Abstractions.Messaging;
using HRHiringSystem.Domain.Entities;
using HRHiringSystem.Domain.Exceptions.Base;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Authentication.Commands.ResetPassword;

internal sealed class ResetPasswordHandler : ICommandHandler<ResetPasswordCommand, bool>
{
    private readonly UserManager<UserEntity> _userManager;

    public ResetPasswordHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return true;

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

        if (result.Succeeded)
            return true;

        throw new BadRequestException(
            result.Errors.ToDictionary(e => e.Code, e => new[] { e.Description }));
    }
}
