using MediatR;
using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.DataLoaders;

public class AddressDataLoader : BatchDataLoader<int, IQueryable<Address>>
{
    private readonly IMediator _mediator;

    public AddressDataLoader(IMediator mediator, IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _mediator = mediator;
    }

    protected override Task<IReadOnlyDictionary<int, IQueryable<Address>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}