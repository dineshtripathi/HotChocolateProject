using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.Schema.ObjectTypes;

public class RegistrationObjectType : ObjectType<Registration>
{
    protected override void Configure(IObjectTypeDescriptor<Registration> descriptor)
    {
        descriptor.Name("Registrations");
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.AddressId);
        descriptor.Field(x => x.Address);
        descriptor.Field(x => x.DateOfRegistration);
        descriptor.Field(x => x.IsDomesticUse);
        descriptor.Field(x => x.IsFreeHold);
        descriptor.Field(x => x.NoOfRegistrant);
        descriptor.Field(x => x.NoOfYearLease);
        descriptor.Field(x => x.RegistrationNumber);
        descriptor.Field(x => x.RegistrationPlace);
        descriptor.Field(x => x.RegistterdName);

    }
}