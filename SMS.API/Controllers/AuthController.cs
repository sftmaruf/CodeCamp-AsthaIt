using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Auths.Commands.CreateSignup;
using Swashbuckle.AspNetCore.Annotations;

namespace SMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    [SwaggerOperation(
        Description = @"First create a student from CreateStudent endpoint
            Take the classid given to that student and enter it here as a student id the default password for a student is 123456."
    )]
    public async Task<ActionResult> SignIn(CreateSigninCommand command)
    {
        var response = await _sender.Send(command);

        if(string.IsNullOrWhiteSpace(response)) return Unauthorized();
        return Ok(response);
    }
}