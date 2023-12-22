using System.Linq.Expressions;

namespace SMS.Application.Common.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<IReadOnlyList<TEntity>> GetAllAsync(string includesProperty = "");
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<TEntity?> GetDynamic(Expression<Func<TEntity, bool>>? predicate = null, string includesProperty = "");
    void Edit(TEntity entityToUpdate);
}