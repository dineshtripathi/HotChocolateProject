using Account.Api.DataLoaders.Group;
using Account.Api.Schema.Query;
using Account.Api.Schema.Query.Extensions;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;
using HotChocolate.Types.Pagination;
using System.Net;
using Account.Api.Schema.ObjectTypesNode;

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
                     DefaultPageSize = 100,
                     MaxPageSize = 100,
                     AllowBackwardPagination = true,
                     InferConnectionNameFromField = true,
                     InferCollectionSegmentNameFromField = true,

                 })
                 .AddProjections()
                 .AddFiltering()
                 .AddSorting()
                .AddType<CustomersQuery>().AddProjections()
                .AddType<CustomerType>()
                .AddType<SearchMortageObjectType>()
                .AddType<CustomerBankAccountQuery>()
                .AddType<MortgageType>()
                .AddTypeExtension<CustomersQueryExtension>()
                .AddDataLoader<MortageDataLoader>()
                .AddMaxExecutionDepthRule(100, true, true);

       
       // services.AddAttributeMiddleware();
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


