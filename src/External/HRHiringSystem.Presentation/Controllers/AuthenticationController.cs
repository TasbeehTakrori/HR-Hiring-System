using AutoMapper;
using HRHiringSystem.Application.Features;
using HRHiringSystem.Application.Features.Authentication.Commands.ForgotPassword;
using HRHiringSystem.Application.Features.Authentication.Commands.ResetPassword;
using HRHiringSystem.Application.Features.Users.Commands.CreateUser;
using HRHiringSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HRHiringSystem.Presentation.Controllers;

[Route("api/Authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /*  private readonly UserManager<UserEntity> _userManager;
      private readonly SignInManager<IdentityUser> _signInManager;
      private readonly IEmailSender _emailSender;*/

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
    {
        var command = _mapper.Map<ResetPasswordCommand>(request);
        await _mediator.Send(command);

        //split it to func
        /*    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token) || model == null || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.ConfirmPassword))
            {
                return BadRequest("Email, token, password, and confirmation password are required.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Password and confirmation password do not match.");
            }

        
    */
        //return BadRequest(result.Errors);
        return Ok();
    }


    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword(
        ForgotPasswordRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<ForgotPasswordCommand>(request);
        await _mediator.Send(command);

        return Ok();
    }
}

public class ResetPasswordViewModel
{
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
