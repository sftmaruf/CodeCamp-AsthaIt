using Sercvices.Interfaces;

namespace Models;

public class SemesterCourseModel
{
    public string CourseId { get; set; } = string.Empty;
    public string SemesterId { get; set; } = string.Empty;
    public string InstructorName { get; set; } = string.Empty;

    private readonly ISemesterService? _semesterService;

    public SemesterCourseModel()
    {
    }

    public SemesterCourseModel(ISemesterService semesterService)
    {
        _semesterService = semesterService;
    }

    public void AddCourse()
    {
        try
        {
            _semesterService!.AddCourse(this);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}