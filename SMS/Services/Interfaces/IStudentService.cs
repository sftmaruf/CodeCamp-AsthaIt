using Entities;
using Models;
using Utility;

namespace Services.Interfaces;

public interface IStudentService 
{
    IResult<IReadOnlyList<Student>> GetAllStudents();
    IResult AddStudent(StudentModel student);
    IResult<Student> GetById(string studentId);
    IResult AssignSemester(string studentId, SemesterModel semesterModel);
    IResult AssignCourse(string studentId, SemesterCourseModel semesterCourseModel);
    IResult DeleteStudent(string id);
}