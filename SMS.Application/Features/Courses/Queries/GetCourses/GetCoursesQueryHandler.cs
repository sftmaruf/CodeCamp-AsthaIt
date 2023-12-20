using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Courses.Queries.GetCourses;

public record GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IReadOnlyList<CourseDto>>
{
    private IUnitOfWork _unitOfWork;

    public GetCoursesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.Courses.GetAllAsync("Instructor");

        var courseDTOs = new List<CourseDto>();
        foreach(var course in courses)
        {
            courseDTOs.Add(new() {
                Id = course.Id,
                Name = course.Name,
                CourseCode = course.CourseCode,
                Credit = course.Credit,
                InstructorName = course.Instructor.Name
            });
        }

        return courseDTOs;
    }
}