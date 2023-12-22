using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Degrees.Commands.CreateDegree;

namespace SMS.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class DegreeController : ControllerBase
{
    private readonly ISender _sender;

    public DegreeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task CreateAsync(CreateDegreeCommand command)
    {
        await _sender.Send(command);
    }
}