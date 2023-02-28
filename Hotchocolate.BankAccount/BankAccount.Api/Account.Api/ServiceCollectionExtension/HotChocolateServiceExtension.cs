using Account.Api.Schema.Query;
using Account.Api.Schema.Query.Extensions;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;
using HotChocolate.Types.Pagination;
using System.Net;

namespace Account.Api.ServiceCollectionExtension;

public static class HotChocolateServices
{
    public static IServiceCollection AddHotChocolateServices(this IServiceCollection services)
    {

        //UseDbContext -> UsePaging -> UseProjection -> UseFiltering -> UseSorting
        services.AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                 .SetPagingOptions(new PagingOptions
                 {
                     IncludeTotalCount = true,
                     LegacySupport = true,
                     DefaultPageSize = 10,
                     MaxPageSize = 100

                 })
                 .AddProjections()
                 .AddFiltering()
                 .AddSorting()
                .AddType<CustomersQuery>()
                .AddType<CustomerBankAccountQuery>()
                .AddTypeExtension<CustomersQueryExtension>()
                .AddMaxExecutionDepthRule(100, true, true);


        return services;
    }
}
public class CustomHttpResponseFormatter : DefaultHttpResponseFormatter
{
    protected override HttpStatusCode OnDetermineStatusCode(
        IQueryResult result, FormatInfo format,
        HttpStatusCode? proposedStatusCode)
    {
        if (result.Errors?.Count > 0 &&
            result.Errors.Any(error => error.Code == "SOME_AUTH_ISSUE"))
        {
            return HttpStatusCode.Forbidden;
        }

        return base.OnDetermineStatusCode(result, format, proposedStatusCode);
    }
}
