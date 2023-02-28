using System.Linq.Expressions;

namespace BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;



public interface IBaseRepositoryProvider<T>
{
    Task<T?> GetByIdAsync(int id);
    Task<IQueryable<T>> GetAllAsync();
    IQueryable<T> GetAllItemByList(IReadOnlyList<string> nameList);
    Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
    Task<IQueryable<T>> GetAllWithInclude(Expression<Func<T, object>> include);
    Task<IQueryable<T>> GetAllWithInclude();
}
