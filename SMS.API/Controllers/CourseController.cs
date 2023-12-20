using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Batches.Commands.CreateBatch;
using SMS.Application.Features.Courses.Queries.GetCourses;
using SMS.Domain.Entities;

namespace SMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class CoourseController : ControllerBase
{
    private readonly ISender _sender;

    public CoourseController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCourses()
    {
        var query = new GetCoursesQuery();
        var courses = await _sender.Send(query);

        return Ok(courses);
    }
}