using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Property.DatabaseEntity;

public abstract class BaseRepositoryProvider<TEntity> : IBaseRepositoryProvider<TEntity> where TEntity : class
{
    private readonly IDbContextFactory<PropertyContext> _dbContextFactory;

    public BaseRepositoryProvider(IDbContextFactory<PropertyContext> contextFactory)
    {
        _dbContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory), "SQL DB context is null , check configuration in appSettings and ServiceCollection"); ;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Set<TEntity>().ToListAsync();
    }

    public IQueryable<TEntity> GetAllItemByList(IReadOnlyList<string> nameList)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Set<TEntity>().Update(entity);
    }

    public Task<IQueryable<TEntity>> GetAllWithInclude(Expression<Func<TEntity, object>> include)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> GetAllWithInclude()
    {
        throw new NotImplementedException();
    }


    public static async Task<IQueryable<TEntity>> GetAllWithInclude(Expression<Func<TEntity, object>> include, PropertyContext context)
    {
        return await Task.FromResult(context.Set<TEntity>().Include(include).AsNoTracking().AsQueryable());
    }

    public static async Task<IQueryable<TEntity>> GetAllWithInclude(PropertyContext context)
    {
        return await IncludeRelatedEntities(context.Set<TEntity>(), context);
    }


    private static async Task<IQueryable<TEntity>> IncludeRelatedEntities(DbSet<TEntity> set, PropertyContext context)
    {
        var entityType = context.Model.FindEntityType(typeof(TEntity));
        var navigations = entityType?.GetNavigations();

        if (navigations != null && !navigations.Any()) return set;
        {
            IQueryable<TEntity> query = navigations.Aggregate<INavigation?, IQueryable<TEntity>>(set, (current, navigation) => current.AsSplitQuery().Include(navigation?.Name ?? string.Empty));

            return await Task.FromResult(query);
        }

    }


}