using HRHiringSystem.Application.Abstractions.Messaging;
using HRHiringSystem.Domain.Entities;
using HRHiringSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;
internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, string>
{
    private readonly UserManager<UserEntity> _userManager;
    public CreateUserCommandHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserEntity
        {
            DisplayName = request.Name,
            UserName = request.Email.Split("@")[0],
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, request.Role);
            //TODO : Send email to user to resetPassword
            return user.Id;
        }
        else
            throw new UserRegistrationFailedException(result.Errors);
    }
}
