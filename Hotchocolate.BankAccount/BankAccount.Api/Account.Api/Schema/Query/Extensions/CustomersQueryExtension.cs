using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.Query.Extensions
{


    public class CustomersQueryExtension : ObjectTypeExtension<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor
                .Field("MothersMaidenName")
                .Type<StringType>()
                .Resolve(context =>
                {
                    var parent = context.Parent<Customer>();
                    return parent.Name;
                    // Omitted code for brevity
                });
        }
    }


}
