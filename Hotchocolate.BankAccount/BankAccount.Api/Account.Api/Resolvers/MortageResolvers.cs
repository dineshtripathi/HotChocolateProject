using Account.Api.DataLoaders.Group;
using BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;
using BankAccount.Domain.Model.Entity;

namespace Account.Api.Resolvers
{
    public class MortageResolvers
    {
        public async Task<IEnumerable<Mortgage>> GetSessionsAsync([Parent]Customer source, SearchMortageByDateAndAmount searchMortage, [Service] IBaseRepositoryProvider<Mortgage> mortageRepository, MortageDataLoader dataLoader, CancellationToken cancellationToken)
        {
            if (source != null && searchMortage != null)
            {
                var mortages = await dataLoader.LoadAsync(source.Id, cancellationToken);
                //   return mortages.Where(m => m.Amount >= searchMortage.MortageAmount && m.Amount <= searchMortage.MortageAmount && m.MortageStartDate >= searchMortage.MortageDate && m.MortageStartDate <= searchMortage.MortageDate);
                return mortages.Where(m => m.Amount >= searchMortage.MortageAmount && m.MortageStartDate >= searchMortage.MortageDate );
            }
            return null;
        }
    }


    //public class MortageResolvers2
    //{
    //    public async Task<IEnumerable<Mortgage>> GetSessionsAsync(
    //        [Parent] Customer customer,
    //        [Service] IBaseRepositoryProvider<Mortgage> mortageRepository,
    //        [Service] MortageDataLoader mortages,
    //        SearchMortageByDateAndAmount searchMortage)
    //    {
    //         awamortages(
    //            "GetMortagesByCustomerId", async (keys) =>
    //            {
    //                // fetch mortages from repository for given CustomerIds
    //                var mortagesByCustomerId = await mortageRepository
    //                    .GetAllAsync(m => keys.Contains(m.CustomerId))
    //                    .ToListAsync();

    //                // group mortages by CustomerId
    //                var groupedMortages = mortagesByCustomerId.GroupBy(m => m.CustomerId);

    //                // prepare dictionary with CustomerId as key and List of Mortages as value
    //                var dictionary = groupedMortages.ToDictionary(
    //                    g => g.Key,
    //                    g => g.AsEnumerable());

    //                // return dictionary of Mortages grouped by CustomerId
    //                return keys.Select(key => dictionary.TryGetValue(key, out var mortages) ? mortages : null);
    //            });

    //        return await mortages.LoadAsync(customer.Id);
    //    }
    //}

}
