using Services.Interfaces;
using Utility;

namespace Models;

public class CourseModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }

    private ICourseService? _courseService;

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
}