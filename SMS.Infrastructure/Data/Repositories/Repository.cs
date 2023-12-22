using System;
using System.Linq.Expressions;
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

    public Task<TEntity?> GetDynamic(Expression<Func<TEntity, bool>>? predicate = null, string includesProperty = "")
    {
        var query = _dbSet.AsQueryable();

        foreach(var include in includesProperty.Split(new char[]{ ','}, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(include);
        }

        if(predicate is not null)
        {
            query = query.Where(predicate);
        }

        var entity = query.FirstOrDefault();
        return Task.FromResult(entity);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(string includesProperty = "")
    {
        var query = _dbSet.AsQueryable();
        foreach(var include in includesProperty.Split(new char[]{ ','}, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(include);
        }
        var items = await query.ToListAsync();

        return items.AsReadOnly();
    }

    public void Edit(TEntity entityToUpdate)
    {
        _dbSet.Entry(entityToUpdate).State = EntityState.Modified;
    }
}