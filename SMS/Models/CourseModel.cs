using Utility;
using Services.Interfaces;
using DepartmenEO = Entities.Department;

namespace Models;

public class CourseModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }
    public  List<DepartmenEO>? Departments { get; set; }

    private readonly ICourseService? _courseService;

    public CourseModel()
    {

    }

    public CourseModel(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public IResult<IReadOnlyList<CourseModel>> GetAllCourses()
    {
        var result = _courseService!.GetAllCourses();   
        
        if(!result.IsSuccess) Result<IReadOnlyList<CourseModel>>.Fail("Fetching courses failed.");

        var coursesEO = result.Data!;
        var courses = new List<CourseModel>();
        foreach(var courseEO in coursesEO)
        {
            courses.Add(new()
            {
                Id = courseEO.Id,
                Name = courseEO.Name,
                Credit = courseEO.Credit
            });
        }
        return Result<IReadOnlyList<CourseModel>>.Success(courses.AsReadOnly());
    }

    public IResult<IReadOnlyList<CourseModel>> GetCoursesByDepartment(string departmentName)
    {
        var result = _courseService!.GetCoursesByDepartment(departmentName);

        if(!result.IsSuccess) Result<IReadOnlyList<CourseModel>>.Fail("Fetching courses failed.");

        var filteredCourses = result.Data!;
        var filteredCoursesModel = new List<CourseModel>();
        foreach(var filteredCourse in filteredCourses)
        {
            var courseModel = new CourseModel
            {
                Id = filteredCourse.Id,
                Name = filteredCourse.Name,
                Credit = filteredCourse.Credit,
                Departments = filteredCourse.Departments
            };

            filteredCoursesModel.Add(courseModel);
        }

        return Result<IReadOnlyList<CourseModel>>.Success(filteredCoursesModel);
    }

    public IResult<CourseModel> GetCourseById(string id)
    {
        var result = _courseService!.GetById(id);

        if(!result.IsSuccess) return Result<CourseModel>.Fail("Course not found");
        return Result<CourseModel>.Success(new CourseModel {
            Id = result.Data!.Id,
            Name = result.Data.Name,
            Credit = result.Data.Credit,
            Departments = result.Data.Departments
        });
    }
}