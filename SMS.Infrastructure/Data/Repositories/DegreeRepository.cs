using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data.Repositories;

public class DegreeRepository : Repository<Degree, Guid>, IDegreeRepository
{
    public DegreeRepository(IApplicationDbContext applicationDbContext) : base((DbContext) applicationDbContext)
    {
    }
}