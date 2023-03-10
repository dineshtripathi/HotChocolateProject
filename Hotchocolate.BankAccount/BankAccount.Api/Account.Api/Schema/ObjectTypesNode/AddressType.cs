using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNode;

public class AddressType : ObjectType<Address>
{
    protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
    {
        descriptor.Field(a => a.Id).Type<NonNullType<IdType>>();
        descriptor.Field(a => a.Street).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.City).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.State).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.ZipCode).Type<NonNullType<StringType>>();
    }
}
