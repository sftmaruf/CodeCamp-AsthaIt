using SMS.Application.Common.Interfaces;
using SMS.Infrastructure.Data.Repositories;

namespace SMS.Infrastructure.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private IApplicationDbContext _applicationDbContext;
    public IStudentRepository Students { get; private set; }
    public ICourseRepository Courses { get; private set; }
    public IBatchRepository Batches { get; private set; }

    public UnitOfWork(IApplicationDbContext applicationDbContext,
        IStudentRepository students,
        ICourseRepository courses,
        IBatchRepository batchRepository)
    {
        _applicationDbContext = applicationDbContext;
        Students = students;
        Courses = courses;
        Batches = batchRepository;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}