using BankAccount.DatabaseEntity.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.DatabaseEntity.DBContextServiceCollection;

public static class HotChocolateSqlConnectionService
{

    public static IServiceCollection AddBankAccountSqlConnectionServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddPooledDbContextFactory<BankAccountDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BankAccountConnection"));
        });
       
        return services;
    }


}
