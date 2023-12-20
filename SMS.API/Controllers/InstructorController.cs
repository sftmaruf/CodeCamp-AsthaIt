using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Instructors.Commands.CreateInstructor;

namespace SMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class InstructorController : ControllerBase
{
    private ISender _sender;

    public InstructorController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task CreateInstructor(CreateInstructorCommand command)
    {
        await _sender.Send(command);
    }
}