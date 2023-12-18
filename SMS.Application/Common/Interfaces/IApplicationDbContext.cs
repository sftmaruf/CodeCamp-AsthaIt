using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;

namespace SMS.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Student> Students { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}