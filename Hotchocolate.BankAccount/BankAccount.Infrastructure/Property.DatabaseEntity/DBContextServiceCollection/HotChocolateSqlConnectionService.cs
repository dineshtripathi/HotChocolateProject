using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Property.DatabaseEntity.DBContextServiceCollection;

public static class HotChocolateServiceExtension
{

    public static IServiceCollection AddPropertySqlConnectionServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPooledDbContextFactory<PropertyContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PropertyAccountConnection"));
        });

        return services;
    }


}