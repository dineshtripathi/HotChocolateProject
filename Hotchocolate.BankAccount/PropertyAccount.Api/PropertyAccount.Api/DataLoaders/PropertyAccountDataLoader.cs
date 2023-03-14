using MediatR;
using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.DataLoaders;

public class PropertyAccountDataLoader :BatchDataLoader<int , IQueryable<Property>>
{
    private readonly IMediator _mediator;

    public PropertyAccountDataLoader(IMediator mediator,IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _mediator = mediator;
    }

  protected override Task<IReadOnlyDictionary<int, IQueryable<Property>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}