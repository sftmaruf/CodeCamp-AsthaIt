using Entities;
using Utility;

namespace Services.Interfaces;

public interface ICourseService
{
    IResult<IReadOnlyList<Course>> GetAllCourses();
}