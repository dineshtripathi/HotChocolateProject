using BankAccount.Domain.Model.Entity;

namespace BankAccount.DatabaseEntity.RepositoryInterface.Interface;

public interface ICustomerRepository
{
    IQueryable<Customer> GetAllCustomer();
}
