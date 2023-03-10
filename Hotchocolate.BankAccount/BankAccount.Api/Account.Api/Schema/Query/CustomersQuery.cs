using BankAccount.CQRS.DataAccess.CQRSQuery.Request;
using BankAccount.Domain.Model.Entity;
using MediatR;

namespace Account.Api.Schema.Query;

[ExtendObjectType("Query")]

public class CustomersQuery
{
    [UsePaging]
   [UseProjection]
    [UseFiltering]
    [UseSorting]

    public async Task<IQueryable<Customer>?> CustomerPagedAndFilter([Service] IMediator queryAllBankAccount,CancellationToken cancellationToken)
    {
        var loads = queryAllBankAccount.Send(new QueryRequest<Customer>() { }).Result.Loads;
        loads = queryAllBankAccount.Send(new QueryRequest<Customer>() { }).Result.Loads;
        return loads;
    }

    //[UsePaging]
    //public async Task<IQueryable<Customer>?> Customers(string name, BankAccountApiBatchProvider<Customer> bankAccountApiBatch)
    //{
    //    var k = name.Split(',').Select(k => k.Trim()).ToList().AsReadOnly();

    //    Expression<Func<Customer, bool>> FilterExpression = p => k.Contains(p.Name);
    //    var cust = (await bankAccountApiBatch.LoadAsync(k, FilterExpression,CancellationToken.None));
    //    return cust.SelectMany(x=>x).AsQueryable();
    //}

  
}