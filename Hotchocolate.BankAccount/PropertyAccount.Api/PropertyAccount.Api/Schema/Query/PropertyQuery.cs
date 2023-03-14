using MediatR;
using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.Schema.Query;

[QueryType]
public class PropertySearchQuery
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Property> PropertySearch(IMediator propertySearchMediator)
    {

        return null;
    }
}