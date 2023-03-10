using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;

public class BaseRepositoryProvider<T> : IBaseRepositoryProvider<T> where T : class
{
    private readonly BankAccountDbContext _bankAccountContext;

    public IDbContextFactory<BankAccountDbContext> ContextFactory { get; }

    public BaseRepositoryProvider(IDbContextFactory<BankAccountDbContext> contextFactory)

    {
        _bankAccountContext = contextFactory.CreateDbContext() ?? throw new ArgumentNullException(nameof(contextFactory), "SQL DB context is null , check configuration in appSettings and ServiceCollection");
        ContextFactory = contextFactory;
    }
    public async Task<T?> GetByIdAsync(int id)
    {


        return await _bankAccountContext.Set<T>().FindAsync(id);
    }

    public async Task<IQueryable<T>> GetAllAsync()
    {
        return await Task.FromResult(_bankAccountContext.Set<T>().AsNoTracking().AsQueryable());
    }

    public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var result = (await GetAllWithInclude()).Where(predicate).AsQueryable();
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        var ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
        Console.WriteLine("RunTime Find Async" + elapsedTime);
        return (await GetAllWithInclude()).Where(predicate).AsQueryable();
    }

    //Not working as its caching data in the memory
    public IQueryable<T> GetAllItemByList(IReadOnlyList<string> nameList)
    {

        var query = GetAllWithInclude().Result.AsNoTracking();

        var parameter = Expression.Parameter(typeof(T), "x");
        var nameProperty = Expression.Property(parameter, typeof(T).GetProperty("Name"));
        var nameListConstant = Expression.Constant(nameList);
        var containsMethod = typeof(List<string>).GetMethod(nameof(List<string>.Contains), new[] { typeof(string) });
        var containsCall = Expression.Call(nameListConstant, containsMethod, nameProperty);
        var expression = Expression.Lambda<Func<T, bool>>(containsCall, parameter);




        var result = query.Where(expression);
        return result;
        // Apply the expression to the query and retrieve the results
    }

    public async Task AddAsync(T entity)
    {
        await _bankAccountContext.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _bankAccountContext.Set<T>().AddRangeAsync(entities);
    }

    public async Task RemoveAsync(T entity)
    {
        _bankAccountContext.Set<T>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _bankAccountContext.Set<T>().RemoveRange(entities);
        await Task.CompletedTask;
    }

    public async Task<IQueryable<T>> GetAllWithInclude(Expression<Func<T, object>> include)
    {
        return await Task.FromResult(_bankAccountContext.Set<T>().Include(include).AsNoTracking().AsQueryable());
    }

    public async Task<IQueryable<T>> GetAllWithInclude()
    {
        return await IncludeRelatedEntities(_bankAccountContext.Set<T>(), _bankAccountContext);
    }


    private async Task<IQueryable<T>> IncludeRelatedEntities(DbSet<T> set, DbContext context)
    {
        var entityType = context.Model.FindEntityType(typeof(T));
        var navigations = entityType?.GetNavigations();

        if (navigations != null && !navigations.Any()) return set;
        {
            IQueryable<T> query = navigations.Aggregate<INavigation?, IQueryable<T>>(set, (current, navigation) => current.AsSplitQuery().Include(navigation?.Name ?? string.Empty));

            return await Task.FromResult(query);
        }

    }
}
