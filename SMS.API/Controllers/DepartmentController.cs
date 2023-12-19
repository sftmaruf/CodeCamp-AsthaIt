using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Departments.Commands;

namespace SMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly ISender _sender;

    public DepartmentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task CreateDepartment(CreateDepartmentCommand command)
    {
        await _sender.Send(command);
    }
}