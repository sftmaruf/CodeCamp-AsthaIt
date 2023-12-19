using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data.Repositories;

public class DepartmentRepository : Repository<Department, Guid>, IDepartmentRepository
{
    public DepartmentRepository(IApplicationDbContext applicationDbContext) : base((DbContext)applicationDbContext)
    {
    }
}