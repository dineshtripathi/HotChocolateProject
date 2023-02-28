using BankAccount.DatabaseEntity.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.DatabaseEntity.DBContextServiceCollection;

public static class HotChocolateServiceExtension
{

    public static IServiceCollection AddSQLConnectionServices(this IServiceCollection services, IConfiguration Configuration)
    {

        services.AddPooledDbContextFactory<BankAccountDBContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }


}
