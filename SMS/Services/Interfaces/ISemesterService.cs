using Entities;
using Models;

namespace Sercvices.Interfaces;

public interface ISemesterService
{
    void CreateSemester(SemesterModel semester);
    List<Semester> GetAllSemesters();
    void AddCourse(SemesterCourseModel semesterCourseModel);
    Semester GetById(string id);
}