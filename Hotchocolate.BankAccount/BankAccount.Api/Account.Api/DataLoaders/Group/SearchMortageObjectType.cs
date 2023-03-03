namespace Account.Api.DataLoaders.Group
{
    public class SearchMortageObjectType:InputObjectType<SearchMortageByDateAndAmount>
    {
        protected override void Configure(IInputObjectTypeDescriptor<SearchMortageByDateAndAmount> descriptor)
        {
            descriptor.Name(nameof(SearchMortageByDateAndAmount));
            descriptor.Field(f => f.MortageAmount).Type<DecimalType>();
            descriptor.Field(f=>f.MortageDate).Type<DateTimeType>();
        }
    }

}
