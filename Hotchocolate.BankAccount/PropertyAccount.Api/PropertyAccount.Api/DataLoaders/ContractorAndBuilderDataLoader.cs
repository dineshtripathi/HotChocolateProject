using MediatR;
using PropertyAccount.Domain.Model;

namespace PropertyAccount.Api.DataLoaders;

public class ContractorAndBuilderDataLoader : BatchDataLoader<int, IQueryable<ContractorAndBuilder>>
{
    private readonly IMediator _mediator;

    public ContractorAndBuilderDataLoader(IMediator mediator, IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _mediator = mediator;
    }

    protected override Task<IReadOnlyDictionary<int, IQueryable<ContractorAndBuilder>>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}