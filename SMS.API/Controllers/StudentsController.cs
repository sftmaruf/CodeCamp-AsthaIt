using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Students.Queries.GetStudents;
using SMS.Application.Features.Students.Commands.CreateStudent;

namespace SMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentsController : ControllerBase
{
    private ISender _sender => HttpContext.RequestServices.GetService<ISender>()!;

    [HttpGet]
    public async Task<List<string>> GetStudents()
    {
        var list = await _sender.Send(new GetStudentsQuery());
        return list;
    }

    [HttpPost]
    public async Task<bool> CreateStudent(CreateStudentCommand command)
    {
        await _sender.Send(command);
        return true;
    }
}