using Account.Api.DataLoaders.Batch;
using Autofac.Core;
using BankAccount.Domain.Model.Entity;
using MediatR;
using System.Dynamic;
using System.Linq.Expressions;

namespace Account.Api.Schema.Query;

[ExtendObjectType("Query")]

public class CustomersQuery
{
    //[UsePaging]
    //public async Task<IQueryable<Customer>?> Customers([Service] IMediator queryAllBankAccount)
    //{
    //    return (await queryAllBankAccount.Send(new QueryRequest<Customer>() { })).Loads;
    //}

    [UsePaging]
    public async Task<IQueryable<Customer>?> Customers(string name, BankAccountApiBatchProvider<Customer> bankAccountApiBatch)
    {
      //  Expression<Func<Customer, bool>>? FilterExpression = c => c.Name.Contains(name);

        var k = name.Split(',').Select(k => k.Trim()).ToList().AsReadOnly();

        Expression<Func<Customer, bool>> FilterExpression = p => k.Contains(p.Name);
        var cust = (await bankAccountApiBatch.LoadAsync(k, FilterExpression,CancellationToken.None));
        cust = (await bankAccountApiBatch.LoadAsync(k, FilterExpression, CancellationToken.None));
        return cust.SelectMany(x=>x).AsQueryable();
    }

    //[UsePaging]
    //[UseProjection]
    //[UseFiltering]
    //[UseSorting]
    //public async Task<IQueryable<Customer>?> Customers(string name, BankAccountApiBatchProvider<Customer> bankAccountApiBatch)
    //{

    //    string[] nameList = name.Split(',');
    //    var keys = name.Split(',').Select(k => k.Trim()).ToList().AsReadOnly();
    //    Expression<Func<Customer, bool>> FilterExpression = p => keys.Contains(p.Name);

    //    var customers = await bankAccountApiBatch.LoadAsync(keys, FilterExpression, CancellationToken.None);
    //    var v= customers.SelectMany(group => group).AsQueryable();
    //    return v;
    //}
}