using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;

namespace SMS.Infrastructure.Data.Repositories;

public abstract class Repository<TEntity, TKey> :
    IRepository<TEntity, TKey> where TEntity : class
{
    private DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }
}