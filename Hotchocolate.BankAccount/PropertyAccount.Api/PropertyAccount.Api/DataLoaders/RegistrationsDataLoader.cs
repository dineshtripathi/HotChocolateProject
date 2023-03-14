using MediatR;
using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.DataLoaders;

public class RegistrationsDataLoader : BatchDataLoader<int, IQueryable<Registration>>
{
    private readonly IMediator _mediator;

    public RegistrationsDataLoader(IMediator mediator, IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _mediator = mediator;
    }

    protected override Task<IReadOnlyDictionary<int, IQueryable<Registration>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}