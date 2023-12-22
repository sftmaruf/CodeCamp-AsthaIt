using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Courses.Queries.GetCourses;

namespace SMS.API.Controllers;

[Authorize]
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