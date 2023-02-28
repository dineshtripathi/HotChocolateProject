
using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNodes;

public class MortgageType : ObjectType<Mortgage>
{
    protected override void Configure(IObjectTypeDescriptor<Mortgage> descriptor)
    {
        descriptor.Field(m => m.Id).Type<NonNullType<IdType>>();
        descriptor.Field(m => m.Amount).Type<NonNullType<DecimalType>>();
        descriptor.Field(m => m.Term).Type<NonNullType<IntType>>();
        descriptor.Field(m => m.InterestRate).Type<NonNullType<DecimalType>>();
        descriptor.Field(m => m.CustomerId).Type<NonNullType<IdType>>();
    }
}
