using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.Query.Extensions
{


    public class CustomersQueryExtension : ObjectTypeExtension<Mortgage>
    {
        protected override void Configure(IObjectTypeDescriptor<Mortgage> descriptor)
        {
            descriptor .Field("NewInterestRate").Type<DecimalType>().IsProjected().Type<DecimalType>().Resolve(context =>
            {
                var interestRate = context.Parent<Mortgage>();

                return (interestRate.InterestRate * 10);

            }).IsProjected();


            //descriptor.Field(x => x.Mortgages.Select(x => x.InterestRate)).IsProjected().Type<DecimalType>().Resolve(context =>
            //{
            //   var interestRate= context.Parent<Mortgage>();

            //    return (interestRate.InterestRate*10);

            //});
        }
    }


}
