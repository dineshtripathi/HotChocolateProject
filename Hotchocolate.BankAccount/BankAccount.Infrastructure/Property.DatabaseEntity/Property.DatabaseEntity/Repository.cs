using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Property.DatabaseEntity;

public abstract class PropertyRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly IDbContextFactory<PropertyContext> _dbContextFactory;

    public PropertyRepository(IDbContextFactory<PropertyContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
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
         using var context =  _dbContextFactory.CreateDbContext();
         context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
         using var context =  _dbContextFactory.CreateDbContext();
         context.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
         using var context =  _dbContextFactory.CreateDbContext();
         context.Set<TEntity>().Update(entity);
    }
}