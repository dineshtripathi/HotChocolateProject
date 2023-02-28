
using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNodes;


public class LoanRelationshipType : ObjectType<LoanRelationship>
{
    protected override void Configure(IObjectTypeDescriptor<LoanRelationship> descriptor)
    {
        descriptor.Field(lr => lr.Id).Type<NonNullType<IdType>>();
        descriptor.Field(lr => lr.Amount).Type<NonNullType<DecimalType>>();
        descriptor.Field(lr => lr.InterestRate).Type<NonNullType<DecimalType>>();
        descriptor.Field(lr => lr.CustomerId).Type<NonNullType<IdType>>();
    }
}
