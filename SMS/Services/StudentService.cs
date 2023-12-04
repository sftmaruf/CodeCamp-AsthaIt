using Data;
using Entities;
using Models;
using Services.Interfaces;
using Utility;

namespace Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResult AddStudent(StudentModel student)
    {
        var isStudentExist = GetById(student.StudentId);
        if (isStudentExist is not null) Result<Student>.Fail("Student already exists");

        var studentEO = new Student
        {
            Id = student.Id,
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            MiddleName = student.MiddleName,
            LastName = student.LastName,
            JoiningBatch = student.JoiningBatch,
            Department = student.Department,
            Degree = student.Degree
        };

        if (student.Id == Guid.Empty) studentEO.FillId();
        _unitOfWork.StudentRepository.Add(studentEO);
        _unitOfWork.SaveChanges();

        return Result<Student>.Success();
    }

    public IResult<IReadOnlyList<Student>> GetAllStudents()
    {
        var students = _unitOfWork.StudentRepository.GetAll();

        if (!students.IsSuccess) return Result<IReadOnlyList<Student>>.Fail();
        return Result<IReadOnlyList<Student>>.Success(students.Data!.AsReadOnly());
    }

    public IResult<Student> GetById(string studentId)
    {
        return _unitOfWork.StudentRepository.GetById(studentId);
    }

    public IResult AssignSemester(string studentId, SemesterModel semesterModel)
    {
        var result = GetById(studentId);
        if (result.IsSuccess)
        {
            var student = result.Data;
            var semester = new Semester
            {
                SemesterCode = semesterModel.SemesterCode,
                Year = semesterModel.Year,
                NumberOfCredits = semesterModel.NumberOfCredits,
                Courses = semesterModel.Courses!
            };

            var isSemesterAssignedToStudent = student!.AttendedSemesters
                .Exists(s => s.GetSemesterCode() == semester.GetSemesterCode());

            if (isSemesterAssignedToStudent)
            {
                return Result<Student>.Fail("Semester already assigned.");
            }

            student!.AttendedSemesters.Add(semester);
            _unitOfWork.StudentRepository.IsPristine = false;
            _unitOfWork.SaveChanges();

            return Result<Student>.Success();
        }

        return Result<Student>.Fail("Student not found");
    }

    public IResult AssignCourse(string studentId, SemesterCourseModel semesterCourseModel)
    {
        var student = GetById(studentId).Data;
        if (student is null) return Result<Student>.Fail("Student not found");

        var semester = student.AttendedSemesters.SingleOrDefault(semester => 
            semester.GetSemesterCode() == semesterCourseModel.SemesterId);
        if (semester is null) return Result<Semester>.Fail("Semester not found");

        var result = _unitOfWork.CourseRepository.GetSingleOrDefault(course => course.Id == semesterCourseModel.CourseId);
        if (!result.IsSuccess) return Result<Course>.Fail("Course not found");
        var course = result.Data!;

        var isCourseAlreadyTaken = student.AttendedSemesters.Any(s => {
            return s.Courses.Any(c => c.Id == semesterCourseModel.CourseId);
        });
        if(isCourseAlreadyTaken) return Result<Semester>.Fail("Course already taken");

        semester.Courses.Add(new()
        {
            Id = course!.Id,
            Name = course.Name,
            Credit = course.Credit,
            InstructorName = semesterCourseModel.InstructorName
        });
        semester.NumberOfCredits += course.Credit;

        _unitOfWork.StudentRepository.IsPristine = false;
        _unitOfWork.SaveChanges();

        return Result<Semester>.Success();
    }

    public IResult DeleteStudent(string studentId)
    {
        var result = _unitOfWork.StudentRepository.DeleteById(studentId);
        _unitOfWork.SaveChanges();

        return result;
    }
}