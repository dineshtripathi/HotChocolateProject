using BankAccount.DatabaseEntity.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.DatabaseEntity.DBContextServiceCollection;

public static class HotChocolateServiceExtension
{

    public static IServiceCollection AddSqlConnectionServices(this IServiceCollection services, IConfiguration configuration)
    {



        services.AddPooledDbContextFactory<BankAccountDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }


}
