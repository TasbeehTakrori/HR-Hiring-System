using HRHiringSystem.Application.Abstractions;
using HRHiringSystem.Application.Abstractions.Messaging;
using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Users.Commands.CreateUser;
public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, string>
{
    private readonly UserManager<UserEntity> _userManager;
    public CreateUserCommandHandler(UserManager<UserEntity> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserEntity
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
            return user.Id;
        else
            //TODO => think to change the exception type
            throw new Exception("Unable to register user");
    }
}
