using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Students.Queries.GetStudents;
using SMS.Application.Features.Students.Commands.CreateStudent;
using SMS.Application.Features.Students.Commands.CreateStudentRegistration;
using Microsoft.AspNetCore.Authorization;

namespace SMS.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class StudentsController : ControllerBase
{
    private ISender _sender => HttpContext.RequestServices.GetService<ISender>()!;

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var list = await _sender.Send(new GetStudentsQuery());
        return Ok(list);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<bool> CreateStudent(CreateStudentCommand command)
    {
        await _sender.Send(command);
        return true;
    }

    [HttpPost]
    public async Task CreateStudentRegistration(CreateStudentRegistrationCommand command)
    {
        await _sender.Send(command);
    }
}