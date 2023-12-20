namespace SMS.Application.Common.Interfaces;

public interface IUnitOfWork
{
    public IStudentRepository Students { get; }
    public ICourseRepository Courses { get; }
    public IBatchRepository Batches { get; }
    public IDepartmentRepository Departments { get; }
    public IDegreeRepository Degrees { get; }
    public IInstructorRepository Instructors { get; }
    public ISemesterRepository Semesters { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
}