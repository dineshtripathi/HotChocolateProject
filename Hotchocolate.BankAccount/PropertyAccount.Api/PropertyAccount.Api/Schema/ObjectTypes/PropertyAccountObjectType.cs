using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.Schema.ObjectTypes;

public class PropertyAccountObjectType :ObjectType<Property>
{
    protected override void Configure(IObjectTypeDescriptor<Property> descriptor)
    {
        descriptor.Name("PropertyData");
        descriptor.Field(x => x.Council);
        descriptor.Field(x => x.Addresses);
        descriptor.Field(x => x.ContractorAndBuilders);
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.IsConstructed);
        descriptor.Field(x => x.County);
        descriptor.Field(x => x.Dateofbuilt);
        descriptor.Field(x => x.NoOfGarages);
        descriptor.Field(x => x.NumberOfFloors);
        descriptor.Field(x => x.PropertyType);
        descriptor.Field(x => x.Rooms);
    }
}