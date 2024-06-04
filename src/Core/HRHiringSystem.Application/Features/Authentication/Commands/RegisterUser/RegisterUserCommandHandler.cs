using HRHiringSystem.Application.Abstractions.Messaging;
using HRHiringSystem.Domain.Entities;
using HRHiringSystem.Domain.Events;
using HRHiringSystem.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRHiringSystem.Application.Features.Authentication.Commands.RegisterUser;
internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMediator _mediator;
    public RegisterUserCommandHandler(
        UserManager<UserEntity> userManager,
        IMediator mediator)
    {
        _userManager = userManager;
        _mediator = mediator;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserEntity
        {
            DisplayName = request.Name,
            UserName = GenerateUserName(request.Email),
            Email = request.Email,
        };

        var registrationResult = await _userManager.CreateAsync(user, request.Password);

        if (registrationResult.Succeeded)
        {
            await AddUserToRole(user, request.Role);
            await PublishUserRegisteredEvent(user);

            return user.Id;
        }
        else
            throw new UserRegistrationFailedException(registrationResult.Errors);
    }

    private async Task PublishUserRegisteredEvent(UserEntity user)
    {
        await _mediator.Publish(new UserRegisteredEvent(user.Id, user.Email!));
    }

    private async Task AddUserToRole(UserEntity user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    private string GenerateUserName(string email)
    {
        return email.Split("@")[0];
    }
}
