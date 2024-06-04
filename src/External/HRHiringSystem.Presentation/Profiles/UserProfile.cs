using AutoMapper;
using HRHiringSystem.Application.Features.Authentication.Commands.RegisterUser;

namespace HRHiringSystem.Presentation.Profiles;
internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserCommand, RegisterUserRequest>()
               .ReverseMap();
    }
}
