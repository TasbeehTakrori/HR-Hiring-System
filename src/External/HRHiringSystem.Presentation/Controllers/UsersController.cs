using AutoMapper;
using HRHiringSystem.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRHiringSystem.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateUserCommand>(request);
        var userId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetUser), new { userId }, userId);
    }

    [HttpGet("userId:guid")]
    public async Task<IActionResult> GetUser(
        Guid userId,
        CancellationToken cancellationToken)
    {
        return Ok();
    }
}
