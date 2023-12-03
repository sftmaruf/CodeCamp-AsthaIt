using Data.Interfaces;
using Entities;

namespace Data;

public interface IUnitOfWork
{
    StudentRepository StudentRepository { get; }
    public CourseRepository CourseRepository { get; }
    public SemesterRepository SemesterRepository { get; }
    List<Semester> Semesters { get; }
    void SaveChanges();
}