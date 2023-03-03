using BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;
using BankAccount.Domain.Model.Entity;
using MediatR;
using System.Linq.Expressions;

namespace Account.Api.DataLoaders.Group
{

    public class MortageDataLoader : GroupedDataLoader<int, Mortgage>
    {
        private readonly IBaseRepositoryProvider<Mortgage> _mortageRepository;

        public MortageDataLoader(IBaseRepositoryProvider<Mortgage> mortageRepository, IBatchScheduler batchScheduler, DataLoaderOptions options, ILogger<GroupedDataLoader<int, Mortgage>> logger)
            : base(batchScheduler, options)
        {
            _mortageRepository = mortageRepository;
        }

        protected override async Task<ILookup<int, Mortgage>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var mortages = await _mortageRepository.FindAsync(m => keys.Contains(m.CustomerId));
            return mortages.ToLookup(m => m.CustomerId);
        }
    }

}
