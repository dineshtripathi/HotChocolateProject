using MediatR;
using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.Schema.Query;

[QueryType]
public class PropertyQuery
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Property> PropertySearch(Property property, IMediator propertySearchMediator)
    {

        return null;
    }
}