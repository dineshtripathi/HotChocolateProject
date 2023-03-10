using BankAccount.CQRS.DataAccess.CQRSQuery.Request;
using BankAccount.Domain.Model.Entity;
using MediatR;

namespace Account.Api.Schema.Query;

[ExtendObjectType("Query")]
public class CustomerBankAccountQuery
{
    public async Task<IQueryable<CustomerBankAccount>?> CustomersBankAccount([Service] IMediator queryAllBankAccount)
    {
        return (await queryAllBankAccount.Send(new QueryRequest<CustomerBankAccount>() { })).Loads;
    }
}
