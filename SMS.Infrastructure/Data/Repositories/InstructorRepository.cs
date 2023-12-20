using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data.Repositories;

public class InstructorRepository : Repository<Instructor, Guid>, IInstructorRepository
{
    public InstructorRepository(IApplicationDbContext applicationDbContext) : base((DbContext) applicationDbContext)
    {
    }
}