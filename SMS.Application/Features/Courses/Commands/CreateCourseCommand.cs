using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Courses.Commands;

public record CreateCourseCommand : IRequest
{
    public string CourseCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }
    public Guid InstructorId { get; set; } = Guid.Empty;

    public Course ToCourse()
    {
        var course = Course.Create(CourseCode, Name, Credit, InstructorId);

        return course;
    }
}