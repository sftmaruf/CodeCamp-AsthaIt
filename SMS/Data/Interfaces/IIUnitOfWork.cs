namespace Data;

public interface IUnitOfWork
{
    StudentRepository StudentRepository { get; }
    public CourseRepository CourseRepository { get; }
    public SemesterRepository SemesterRepository { get; }
    void SaveChanges();
}