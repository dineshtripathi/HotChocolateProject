using BankAccount.Domain.Model.Entity;
using GreenDonut;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Account.Api.DataLoaders.Group
{


    //public class BankAccountApiBatchProvider<Customer> : GroupedDataLoader<string, Customer>
    //{
    //    private IMediator _mediator;
    //    private readonly IBatchScheduler batchScheduler;

    //    private Expression<Func<Customer?, bool>>? _predicate;

    //    public BankAccountApiBatchProvider(IMediator Mediator, Expression<Func<Customer, bool>> predicate, IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    //    {
    //        _mediator = Mediator;
    //        this.batchScheduler = batchScheduler;
    //        options.Caching = true;
    //        _predicate = predicate;
    //    }



    //    protected override async Task<ILookup<string, Customer?>?> LoadGroupedBatchAsync(IReadOnlyList<string> names, CancellationToken cancellationToken)
    //    {
    //        ILookup<string, Customer?>? customerLookup = null;
    //        IQueryable<Customer?>? loads = (await _mediator.Send(new QueryRequest<Customer?>() { FilterExpression = _predicate }, cancellationToken)).Loads;
    //        customerLookup  = loads?.Where(_predicate).ToLookup(c => (string)typeof(Customer?).GetProperty("Name")?.GetValue(c));
    //        return customerLookup;
    //    }

    //    public Task<ILookup<string, Customer>> LoadAsync(
    //     IReadOnlyList<string> names,
    //    Expression<Func<Customer, bool>> predicate,
    //     CancellationToken cancellationToken)
    //    {
    //        _predicate = predicate;
    //        return LoadGroupedBatchAsync(names, cancellationToken);
    //    }




    //}

    public class BankAccountApiBatchProvider<Customer> : GroupedDataLoader<string, Customer>
    {
        private IMediator _mediator;
        private readonly IBatchScheduler batchScheduler;

        private Expression<Func<Customer, bool>> _predicate;

        public BankAccountApiBatchProvider(IMediator Mediator, Expression<Func<Customer, bool>> predicate, IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
        {
            _mediator = Mediator;
            this.batchScheduler = batchScheduler;
            options.Caching = true;
            _predicate = predicate;
        }

        protected override async Task<ILookup<string, Customer>> LoadGroupedBatchAsync(IReadOnlyList<string> names, CancellationToken cancellationToken)
        {
            ILookup<string, Customer>? customerLookup = null;
            // var c = (await _mediator.Send(new QueryRequest<Customer>() { }, cancellationToken)).Loads;
            var customers = (await _mediator.Send(new QueryRequest<Customer>() { FilterExpression = _predicate }, cancellationToken)).Loads;
            Func<Customer, string> keySelector = c => (string)typeof(Customer).GetProperty("Name").GetValue(c); ;
            return customers.ToLookup(keySelector);
        }


        public Task<ILookup<string, Customer>> LoadAsync(
         IReadOnlyList<string> names,
        Expression<Func<Customer, bool>> predicate,
         CancellationToken cancellationToken)
        {
            _predicate = predicate;
            return LoadGroupedBatchAsync(names, cancellationToken);
        }

    }

}
