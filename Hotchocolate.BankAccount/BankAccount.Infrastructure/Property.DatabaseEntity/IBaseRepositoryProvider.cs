using System.Linq.Expressions;

namespace Property.DatabaseEntity;

public interface IBaseRepositoryProvider<TEntity> 
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    IQueryable<TEntity> GetAllItemByList(IReadOnlyList<string> nameList);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    Task<IQueryable<TEntity>> GetAllWithInclude(Expression<Func<TEntity, object>> include);
    Task<IQueryable<TEntity>> GetAllWithInclude();
}