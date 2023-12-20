using SMS.Application.Common.Interfaces;

namespace SMS.Infrastructure.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private IApplicationDbContext _applicationDbContext;
    public IStudentRepository Students { get; private set; }
    public ICourseRepository Courses { get; private set; }
    public IBatchRepository Batches { get; private set; }
    public IDepartmentRepository Departments { get; private set; }
    public IDegreeRepository Degrees { get; private set; }
    public IInstructorRepository Instructors { get; private set; }
    public ISemesterRepository Semesters { get; private set; }

    public UnitOfWork(IApplicationDbContext applicationDbContext,
        IStudentRepository students,
        ICourseRepository courses,
        IBatchRepository batchRepository,
        IDepartmentRepository departmentRepository,
        IDegreeRepository degreeRepository,
        IInstructorRepository instructorRepository,
        ISemesterRepository semesters)
    {
        _applicationDbContext = applicationDbContext;
        Students = students;
        Courses = courses;
        Batches = batchRepository;
        Departments = departmentRepository;
        Degrees = degreeRepository;
        Instructors = instructorRepository;
        Semesters = semesters;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}