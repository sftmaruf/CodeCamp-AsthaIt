using Data;
using Entities;
using Models;
using Sercvices.Interfaces;

namespace Services;

public class SemesterService : ISemesterService
{
    private readonly IUnitOfWork _unitOfWork;

    public SemesterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void CreateSemester(SemesterModel semester)
    {
        _unitOfWork.Semesters.Add(new()
        {
            SemesterCode = semester.SemesterCode,
            Year = semester.Year,
            NumberOfCredits = semester.NumberOfCredits
        });
    }

    public List<Semester> GetAllSemesters()
    {
        return _unitOfWork.Semesters;
    }

    public void AddCourse(SemesterCourseModel semesterCourseModel)
    {
        if(string.IsNullOrWhiteSpace(semesterCourseModel.CourseId) || string.IsNullOrWhiteSpace(semesterCourseModel.SemesterId))
        {
            throw new ArgumentException("CoueseId and SemesterId are required");
        }

        var courseResult = _unitOfWork.CourseRepository.GetSingleOrDefault(course => course.Id == semesterCourseModel.CourseId)!;
        if(!courseResult.IsSuccess) throw new ArgumentException("Course not found");
        var course = courseResult.Data!;

        var semester = _unitOfWork.Semesters.SingleOrDefault(semester => semester.GetSemesterCode() == semesterCourseModel.SemesterId)!;
        if(semester == null) throw new ArgumentException("Semester not found");

        semester.Courses.Add(new()
        {
            Id = course.Id,
            Name = course.Name,
            Credit = course.Credit,
            InstructorName = semesterCourseModel.InstructorName,
        });
        
        semester.NumberOfCredits += course.Credit;
    }

    public Semester GetById(string semesterCode)
    {
        return _unitOfWork.Semesters.SingleOrDefault(semester => semester.SemesterCode+semester.Year == semesterCode)!;
    }
}