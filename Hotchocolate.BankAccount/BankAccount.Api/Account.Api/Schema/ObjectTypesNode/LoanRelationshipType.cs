
using BankAccount.Domain.Model.Entity;

namespace Account.Api.Schema.ObjectTypesNode;


public class LoanRelationshipType : ObjectType<LoanRelationship>
{
    protected override void Configure(IObjectTypeDescriptor<LoanRelationship> descriptor)
    {
        descriptor.Field(lr => lr.Id).Type<NonNullType<IdType>>();
        descriptor.Field(lr => lr.Amount).Type<NonNullType<DecimalType>>();
        descriptor.Field(lr => lr.InterestRate).Type<NonNullType<DecimalType>>();
        descriptor.Field(lr => lr.CustomerId).Type<NonNullType<IdType>>();
        descriptor.Field(lr => lr.Balance).Type<NonNullType<DecimalType>>();
        descriptor.Field(lr => lr.Currency).Type<NonNullType<StringType>>();
        descriptor.Field(lr => lr.IsLoan).Type<NonNullType<IntType>>();
        descriptor.Field(lr => lr.LoanApprovedDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(lr => lr.LoanEndDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(lr => lr.LoanStartDate).Type<NonNullType<DateTimeType>>();
    }
}
