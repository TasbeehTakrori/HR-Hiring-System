using AutoMapper;
using HRHiringSystem.Application.Features.Authentication.Commands.ForgotPassword;
using HRHiringSystem.Application.Features.Authentication.Commands.ResetPassword;

namespace HRHiringSystem.Presentation.Profiles;
internal class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<ForgotPasswordCommand, ForgotPasswordRequest>()
               .ReverseMap();
        CreateMap<ResetPasswordCommand, ResetPasswordRequest>()
               .ReverseMap();
    }
}
