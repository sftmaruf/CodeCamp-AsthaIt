using Entities;
using Models;
using Utility;

namespace Services.Interfaces;

public interface IStudentService 
{
    IResult<IReadOnlyList<Student>> GetAllStudents();
    IResult AddStudent(StudentModel student);
    IResult<Student> GetById(Guid id);
    IResult AssignSemester(Guid studentId, SemesterModel semesterModel);
    IResult AssignCourse(Guid studentId, SemesterCourseModel semesterCourseModel);
    IResult DeleteStudent(Guid id);
}