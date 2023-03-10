using Microsoft.EntityFrameworkCore;

namespace Property.DatabaseEntity;

public class PropertyContextFactory : IDbContextFactory<PropertyContext>
{
    private readonly DbContextOptions<PropertyContext> _options;

    public PropertyContextFactory(DbContextOptions<PropertyContext> options)
    {
        _options = options;
    }

    public PropertyContext CreateDbContext()
    {
        return new PropertyContext(_options);
    }
}