using BankAccount.DatabaseEntity.RepositoryInterface.Interface;
using BankAccount.Domain.Model.Entity;

namespace BankAccount.DatabaseEntity.RepositoryInterface.Implementation;

public class CustomerRepository : ICustomerRepository
{
    public CustomerRepository()
    {

    }
    public IQueryable<Customer> GetAllCustomer()
    {
        throw new NotImplementedException();
    }
}