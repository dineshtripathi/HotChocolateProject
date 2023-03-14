
using HotChocolate.Types.Pagination;

namespace PropertyAccount.Api.ServiceCollectionExtension;

public static class HotchocolateServiceExtension
{
    public static IServiceCollection AddHotchocolateServiceCollection(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGraphQLServer().AddTypes().AddQueryType(q => q.Name("Query"))
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
            .AddSorting();

        return services;


    }
}