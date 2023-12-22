using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Semesters.Commands.CreateSemester;
using SMS.Application.Features.Semesters.Queries.GetSemesters;

namespace SMS.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class SemesterController : ControllerBase
{
    private readonly ISender _sender;

    public SemesterController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetSemesters()
    {
        var query = new GetSemestersQuery();
        var semesters = await _sender.Send(query);

        return Ok(semesters);
    }

    [HttpPost]
    public async Task CreateSemester(CreateSemesterCommand command)
    {
        await _sender.Send(command);
    }
}