using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNodes;

public class CustomerType : ObjectType<Customer>
{
    protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
    {
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.Name).Type<NonNullType<StringType>>();
        descriptor.Field(c => c.Email).Type<NonNullType<StringType>>();
        descriptor.Field(c => c.Addresses).Type<NonNullType<ListType<NonNullType<AddressType>>>>();
        descriptor.Field(c => c.CustomerBankAccounts).Type<NonNullType<ListType<NonNullType<BankAccountType>>>>();
        descriptor.Field(c => c.Mortgages).Type<NonNullType<ListType<NonNullType<MortgageType>>>>();
        descriptor.Field(c => c.LoanRelationships).Type<NonNullType<ListType<NonNullType<LoanRelationshipType>>>>();
    }
}
