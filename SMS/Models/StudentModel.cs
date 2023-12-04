using Utility;
using Entities;
using Services.Interfaces;

namespace Models;

public class StudentModel 
{
    public Guid Id { get; set;  } = Guid.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string FirstName { get; set;} = string.Empty;
    public string MiddleName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JoiningBatch { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
     public List<Semester> AttendedSemesters { get; set; } = new();

    private readonly IStudentService? _studentService;

    public StudentModel()
    {

    }

    public StudentModel(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public string GetFullName() => $"{FirstName} {MiddleName} {LastName}";

    public IResult AddStudent()
    {
        try
        {
            return _studentService!.AddStudent(this);
        }
        catch 
        {
            return Result<StudentModel>.Fail("New student creation failed");
        }
    }

    public IResult<IReadOnlyList<StudentModel>> GetAllStudents() 
    {
        var result = _studentService!.GetAllStudents();

        if(result.IsSuccess)
        {
            var students = new List<StudentModel>();

            foreach(var student in result.Data!)
            {
                students.Add(new() 
                {
                    Id =  student.Id,
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    MiddleName = student.MiddleName,
                    LastName = student.LastName,
                    JoiningBatch = student.JoiningBatch,
                    Department = student.Department,
                    Degree = student.Degree,
                    AttendedSemesters = student.AttendedSemesters,  
                });
            }
            
            return Result<IReadOnlyList<StudentModel>>.Success(students);
        }

        return Result<IReadOnlyList<StudentModel>>.Fail();
    }

    public IResult<StudentModel> GetById(string studentId)
    {
        var result = _studentService!.GetById(studentId);

        if(result.IsSuccess)
        {
            var studentEO = result.Data;
            if(studentEO == null) return default!;
            
            var student = new StudentModel {
                Id = studentEO.Id,
                FirstName = studentEO.FirstName,
                MiddleName = studentEO.MiddleName,
                LastName = studentEO.LastName,
                Department = studentEO.Department,
                Degree = studentEO.Degree,
                JoiningBatch = studentEO.JoiningBatch,
                AttendedSemesters = studentEO.AttendedSemesters
            };

            return Result<StudentModel>.Success(student);
        }

        return Result<StudentModel>.Fail("Student not found");
    }
    
    public IResult AddSemester(string studentId, SemesterModel semesterModel)
    {
        return _studentService!.AssignSemester(studentId, semesterModel);
    }

    public IResult AddCourse(string studentId, SemesterCourseModel semesterCourseModel)
    {
        try
        {
            return _studentService!.AssignCourse(studentId, semesterCourseModel);
        }
        catch
        {
            return Result<StudentModel>.Fail("Course assignment failed");
        }
    }

    public IResult DeleteStudent(string studentId)
    {
        try
        {
            return _studentService!.DeleteStudent(studentId);
        }
        catch
        {
             return Result<StudentModel>.Fail("Student deletion failed");
        }
    }
}