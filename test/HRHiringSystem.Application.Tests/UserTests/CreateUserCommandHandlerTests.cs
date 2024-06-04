using AutoFixture.Xunit2;
using FluentAssertions;
using HRHiringSystem.Application.Features.Authentication.Commands.RegisterUser;
using HRHiringSystem.Application.Tests.Attributes;
using HRHiringSystem.Domain.Entities;
using HRHiringSystem.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace HRHiringSystem.Application.Tests.AuthenticationTests;

public partial class CreateUserCommandHandlerTests
{

    [Theory]
    [AutoMoqData]
    public async Task Handle_ValidUser_ReturnsUserId(
        [Frozen] Mock<FakeUserManager> userManagerMock,
        RegisterUserCommand createUserCommand)
    {
        // Arrange
        userManagerMock.Setup(m => m.CreateAsync(It.IsAny<UserEntity>()))
            .ReturnsAsync(IdentityResult.Success);
        RegisterUserCommandHandler sut = new RegisterUserCommandHandler(userManagerMock.Object);

        // Act
        var result = await sut.Handle(createUserCommand, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        userManagerMock.Verify(x => x.CreateAsync(It.IsAny<UserEntity>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    public async Task Handle_InvalidUser_ThrowsException(
         [Frozen] Mock<FakeUserManager> userManagerMock,
        RegisterUserCommand createUserCommand)
    {
        userManagerMock.Setup(m => m.CreateAsync(It.IsAny<UserEntity>()))
            .ReturnsAsync(IdentityResult.Failed([]));
        //ToUpdate
        RegisterUserCommandHandler sut = new RegisterUserCommandHandler(userManagerMock.Object);

        // Act
        var action = async () => await sut.Handle(createUserCommand, It.IsAny<CancellationToken>());

        // Assert
        await action.Should().ThrowExactlyAsync<UserRegistrationFailedException>();
        userManagerMock.Verify(x => x.CreateAsync(It.IsAny<UserEntity>()), Times.Once);
    }
}
