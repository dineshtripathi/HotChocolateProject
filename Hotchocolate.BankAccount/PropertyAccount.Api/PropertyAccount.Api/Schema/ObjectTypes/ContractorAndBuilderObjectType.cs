using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.Schema.ObjectTypes;

public class ContractorAndBuilderObjectType : ObjectType<ContractorAndBuilder>
{
    protected override void Configure(IObjectTypeDescriptor<ContractorAndBuilder> descriptor)
    {
        descriptor.Name("ContractorAndBuilders");
        descriptor.Field(x => x.PropertyId);
        descriptor.Field(x => x.AgreementNumber);
        descriptor.Field(x => x.CompanyRegistrationNumber);
        descriptor.Field(x => x.ContractorBuilderName);
        descriptor.Field(x => x.DateOfContract);
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.IsSubcontractor);
        descriptor.Field(x => x.Property);
        descriptor.Field(x => x.NoOfHouseAllocated);
        
    }
}