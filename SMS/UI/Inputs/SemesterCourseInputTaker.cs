using System.Text;
using Models;
using UI.Interfaces;

namespace UI;

public class SemesterCourseInputTaker : IInputTaker
{
    private readonly SemesterCourseModel _semesterCourseModel;
    private readonly CourseModel _courseModel;
    private readonly StudentModel _studentModel;

    public SemesterCourseInputTaker(SemesterCourseModel semesterCourseModel, CourseModel courseModel, StudentModel studentModel)
    {
        _semesterCourseModel = semesterCourseModel;
        _courseModel = courseModel;
        _studentModel = studentModel;
    }

    public void TakeInput()
    {
        ValidateStudent();
        ShowAvailableCourses();

        var courseId = TakeCourseInput();
        var semesterId = TakeInputSemester();

        Console.Write("Course Instructor: ");
        var instructorName = Console.ReadLine();

        _semesterCourseModel.CourseId = courseId!;
        _semesterCourseModel.SemesterId = semesterId!;
        _semesterCourseModel.InstructorName = instructorName!;
    }

    private void ValidateStudent()
    {
        var studentResult = _studentModel.GetById(_studentModel.StudentId);
        if(!studentResult.IsSuccess) throw new Exception("Student not found.");
        var student = studentResult.Data!;
        if(student.AttendedSemesters.Count == 0)
        {
            throw new Exception("Student must need a semester before adding courses.");
        }
    }

    private void ShowAvailableCourses()
    {
        var studentResult = _studentModel.GetById(_studentModel.StudentId);
        if(!studentResult.IsSuccess) throw new Exception("Courses not available");
        var student = studentResult.Data!;

        var coursesResult = _courseModel.GetCoursesByDepartment(student.Department);
        if(!coursesResult.IsSuccess) throw new Exception("Courses not available");;
        var courses = coursesResult.Data!;

        var maxPadding = courses.Max(course => course.Id.Length);
        Console.WriteLine("\nAvailable courses: ");
        Console.WriteLine($"\tCredit\tId{GeneratePadding(maxPadding)}\tName");
        foreach(var course in courses)
        {
            Console.WriteLine($"\t{course.Credit}\t{course.Id}{GeneratePadding(maxPadding)}\t{course.Name}");
        }
        Console.WriteLine();
    }

    private string GeneratePadding(int count)
    {
        var padding = new StringBuilder();
        for(var i = 0; i < count; i++) padding.Append(' ');
        return padding.ToString();
    }

    private string TakeCourseInput()
    {
        Console.Write("Course Id: ");
        var courseId = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(courseId)) throw new Exception("Id is required.");

        courseId = courseId.Trim();
        var courseResult = _courseModel.GetCourseById(courseId!);
        if(!courseResult.IsSuccess) throw new Exception("Course not available.");
        
        return courseId;
    }

    private string TakeInputSemester()
    {
        Console.Write("Semester Id: ");
        var semesterId = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(semesterId)) throw new Exception("Id is required.");

        semesterId = semesterId.Trim();
        var studentResult = _studentModel.GetById(_studentModel.StudentId);
        if(!studentResult.IsSuccess) throw new Exception("Something went wrong.");
        var student = studentResult.Data!;

        var isSemesterExist = student.AttendedSemesters.Exists(s => s.GetSemesterCode() == semesterId);
        if(!isSemesterExist) throw new Exception("You're not assigned in this semester.");

        return semesterId!;
    }
}