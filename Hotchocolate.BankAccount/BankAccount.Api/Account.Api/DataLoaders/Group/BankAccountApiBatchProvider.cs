using MediatR;
using System.Linq.Expressions;
using BankAccount.CQRS.DataAccess.CQRSQuery.Request;

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

    public class BankAccountApiBatchProvider<TCustomer> : GroupedDataLoader<string, TCustomer>
    {
        private IMediator _mediator;
        private readonly IBatchScheduler _batchScheduler;

        private Expression<Func<TCustomer, bool>> _predicate;

        public BankAccountApiBatchProvider(IMediator mediator, Expression<Func<TCustomer, bool>> predicate, IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
        {
            _mediator = mediator;
            this._batchScheduler = batchScheduler;
            options.Caching = true;
            _predicate = predicate;
        }

        protected override async Task<ILookup<string, TCustomer>> LoadGroupedBatchAsync(IReadOnlyList<string> names, CancellationToken cancellationToken)
        {
            ILookup<string, TCustomer>? customerLookup = null;
            // var c = (await _mediator.Send(new QueryRequest<Customer>() { }, cancellationToken)).Loads;
            var customers = (await _mediator.Send(new QueryRequest<TCustomer>() { FilterExpression = _predicate }, cancellationToken)).Loads;
            Func<TCustomer, string> keySelector = c => (string)typeof(TCustomer).GetProperty("Name").GetValue(c); ;
            return customers.ToLookup(keySelector);
        }


        public Task<ILookup<string, TCustomer>> LoadAsync(
         IReadOnlyList<string> names,
        Expression<Func<TCustomer, bool>> predicate,
         CancellationToken cancellationToken)
        {
            _predicate = predicate;
            return LoadGroupedBatchAsync(names, cancellationToken);
        }

    }

}
