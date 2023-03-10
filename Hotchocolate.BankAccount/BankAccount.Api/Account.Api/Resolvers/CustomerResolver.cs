using BankAccount.Domain.Model.Entity;

namespace Account.Api.Resolvers
{
    public class CustomerResolver
    {
        public decimal CustomerInterestRateResolver([Parent] Mortgage mortgage)
        {
            mortgage.InterestRate = ( mortgage.InterestRate * Convert.ToDecimal(0.1));
            return mortgage.InterestRate;
        }
    }
}
