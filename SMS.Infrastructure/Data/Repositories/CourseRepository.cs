using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data.Repositories;

public class CourseRepository : Repository<Course, Guid>, ICourseRepository
{
    public CourseRepository(IApplicationDbContext applicationDbContext)
        : base((DbContext) applicationDbContext)
    {
    }
}