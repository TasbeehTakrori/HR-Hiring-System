using AutoMapper;
using HRHiringSystem.Application.Features.Users.Commands.CreateUser;

namespace HRHiringSystem.Application.Profiles;
internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, CreateUserRequest>()
               .ReverseMap();
    }
}
