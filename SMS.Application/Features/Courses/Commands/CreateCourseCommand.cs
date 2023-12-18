using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Courses.Commands;

public record CreateCourseCommand : IRequest
{
    public string CourseCode { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }

    public Course ToCourse(CreateCourseCommand command)
    {
        var course = Course.Create(command.CourseCode, command.Name, command.Credit);
        return course;
    }
}