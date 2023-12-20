using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data.Repositories;

public class SemesterRepository  : Repository<Semester, Guid>, ISemesterRepository
{
    public SemesterRepository(IApplicationDbContext applicationDbContext) : base((DbContext) applicationDbContext)
    {
    }
}