using MediatR;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Courses.Queries.GetCourses;

public record GetCoursesQuery : IRequest<IReadOnlyList<CourseDto>>
{

}