using HRHiringSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HRHiringSystem.Application.Tests.AuthenticationTests;

public class FakeUserManager : UserManager<UserEntity>
{
    public FakeUserManager()
        : base(new Mock<IUserStore<UserEntity>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<UserEntity>>().Object,
            new IUserValidator<UserEntity>[0],
            new IPasswordValidator<UserEntity>[0],
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<UserEntity>>>().Object)
    {
    }
}



