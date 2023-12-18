using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data.Repositories;

public class BatchRepository : Repository<Batch, Guid>, IBatchRepository
{
    public BatchRepository(IApplicationDbContext applicationDbContext) : base((DbContext) applicationDbContext)
    {
    }
}