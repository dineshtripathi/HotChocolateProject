using BankAccount.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.DatabaseEntity.ContextProvider;
public interface IBankAccountContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Address> Addresses { get; set; }
    DbSet<CustomerBankAccount> CustomerBankAccounts { get; set; }
    DbSet<Mortgage> Mortgages { get; set; }
    DbSet<LoanRelationship> LoanRelationships { get; set; }
}
