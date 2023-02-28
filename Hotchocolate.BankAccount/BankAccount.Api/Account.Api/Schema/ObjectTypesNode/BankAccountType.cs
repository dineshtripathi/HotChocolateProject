using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNode;

public class BankAccountType : ObjectType<CustomerBankAccount>
{
    protected override void Configure(IObjectTypeDescriptor<CustomerBankAccount> descriptor)
    {
        descriptor.Field(b => b.Id).Type<NonNullType<IdType>>();
        descriptor.Field(b => b.AccountNumber).Type<NonNullType<StringType>>();
        descriptor.Field(b => b.BankName).Type<NonNullType<StringType>>();
    }
}
