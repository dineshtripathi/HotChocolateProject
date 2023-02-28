using Account.Api.DataLoaders.Group;
using Account.Api.Resolvers;
using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNode;

public class CustomerType : ObjectType<Customer>
{
    protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
    {
        descriptor.Field(c => c.Id)
            .IsProjected();
        descriptor.Field(c => c.Name)            ;

        descriptor.Field(c => c.Email)            ;

        descriptor.Field(c => c.Addresses).IsProjected();

        descriptor.Field(c => c.CustomerBankAccounts).IsProjected()           ;

        descriptor.Field(c => c.Mortgages).IsProjected()
      .Argument("searchMortage", x => x.Type<SearchMortageObjectType>())
      .ResolveWith<MortageResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default!, default!));


        descriptor.Field(c => c.LoanRelationships).IsProjected();
    }
}

