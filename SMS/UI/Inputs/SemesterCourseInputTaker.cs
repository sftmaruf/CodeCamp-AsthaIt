using Models;
using UI.Interfaces;

namespace UI;

public class SemesterCourseInputTaker : IInputTaker
{
    private readonly SemesterCourseModel _semesterCourseModel;

    public SemesterCourseInputTaker(SemesterCourseModel semesterCourseModel)
    {
        _semesterCourseModel = semesterCourseModel;
    }

    public void TakeInput()
    {
        Console.Write("Course Id: ");
        var courseId = Console.ReadLine();
        Console.Write("Semester Id: ");
        var semesterId = Console.ReadLine();
        Console.Write("Course Instructor: ");
        var instructorName = Console.ReadLine();

        _semesterCourseModel.CourseId = courseId!;
        _semesterCourseModel.SemesterId = semesterId!;
        _semesterCourseModel.InstructorName = instructorName!;
    }
}