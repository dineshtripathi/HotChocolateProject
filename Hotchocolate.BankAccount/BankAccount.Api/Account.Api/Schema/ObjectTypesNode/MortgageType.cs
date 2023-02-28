using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNode;

public class MortgageType : ObjectType<Mortgage>
{
    protected override void Configure(IObjectTypeDescriptor<Mortgage> descriptor)
    {
        descriptor.Field(m => m.Id).Type<NonNullType<IdType>>();
        descriptor.Field(m => m.Amount).Type<NonNullType<DecimalType>>();
        descriptor.Field(m => m.Term).Type<NonNullType<IntType>>();
        descriptor.Field(m => m.InterestRate).Type<NonNullType<DecimalType>>();
        descriptor.Field(m => m.CustomerId).Type<NonNullType<IdType>>();
        descriptor.Field(m => m.MortageEndDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(m => m.MortageMonthlyDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(m => m.MortageStartDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(m => m.CurrencyCode).Type<NonNullType<StringType>>();
        descriptor.Field(m => m.CommissionCharge).Type<NonNullType<DecimalType>>();

}
}
