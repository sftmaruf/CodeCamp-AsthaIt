using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data.Repositories;

public class StudentRepository : Repository<Student, Guid>, IStudentRepository
{
    public StudentRepository(IApplicationDbContext applicationDbContext)
        : base((DbContext) applicationDbContext)
    {
    }
}