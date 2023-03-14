using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.Schema.ObjectTypes;

public class AddressAccountObjectType : ObjectType<Address>
{
    protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
    {
        descriptor.Name("PropertyAddress");
        descriptor.Field(x => x.AreaName);
        descriptor.Field(x => x.City);
        descriptor.Field(x => x.DateToMove);
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.HouseNumber);
        descriptor.Field(x => x.IsReadyToMove);
        descriptor.Field(x => x.PostCode);
        descriptor.Field(x => x.Property);
        descriptor.Field(x => x.PropertyId);
        descriptor.Field(x => x.Registrations);
        descriptor.Field(x => x.StreetName);
    }
}