using BankAccount.Domain.Model.Entity;

namespace BankAccount.DatabaseEntity.RepositoryInterface.Interface;

public interface IAccountRespository
{
    IQueryable<CustomerBankAccount> GetAllAccount();
}