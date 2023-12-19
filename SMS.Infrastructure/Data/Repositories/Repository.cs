using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;

namespace SMS.Infrastructure.Data.Repositories;

public abstract class Repository<TEntity, TKey> :
    IRepository<TEntity, TKey> where TEntity : class
{
    protected DbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }
}