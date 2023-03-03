using Autofac;
using BankAccount.DatabaseEntity.ContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;

namespace BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;

public class BaseRepositoryProvider<T> : IBaseRepositoryProvider<T> where T : class
{
    private BankAccountDBContext _bankAccountContext;

    public IDbContextFactory<BankAccountDBContext> ContextFactory { get; }

    public BaseRepositoryProvider(IDbContextFactory<BankAccountDBContext> contextFactory)

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
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        var result = (await GetAllWithInclude()).Where(predicate).AsQueryable();
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
        Console.WriteLine("RunTime Find Async" + elapsedTime);
        return (await GetAllWithInclude()).Where(predicate).AsQueryable();
    }

    //Not working as its caching data in the memory
    public IQueryable<T> GetAllItemByList(IReadOnlyList<string> nameList)
    {

        IQueryable<T> query = GetAllWithInclude().Result.AsNoTracking();

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
        var navigations = entityType.GetNavigations();

        if (navigations.Any())
        {
            IQueryable<T> query = set;

            foreach (var navigation in navigations)
            {
                query = query.AsSplitQuery().Include(navigation.Name);
            }

            return await Task.FromResult(query);
        }

        return set;
    }
}
