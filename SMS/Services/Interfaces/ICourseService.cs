using Entities;
using Utility;

namespace Services.Interfaces;

public interface ICourseService
{
    IResult<IReadOnlyList<Course>> GetAllCourses();
    IResult<IReadOnlyList<Course>> GetCoursesByDepartment(string departmentName);
    IResult<Course> GetById(string id);
}