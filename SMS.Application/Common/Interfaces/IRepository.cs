namespace SMS.Application.Common.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(TKey id);
}