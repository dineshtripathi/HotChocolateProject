using MediatR;
using Property.DatabaseEntity;
using PropertyAccount.CQRS.DataAccess.CQRSQuery.Response;

namespace PropertyAccount.CQRS.DataAccess.CQRSQuery.Handler;

public class QueryRequestHandler<TEntity> : IRequestHandler<QueryRequest<TEntity>, QueryResponse<TEntity>>
{
    private IBaseRepositoryProvider<TEntity> BaseRepositoryProvider { get; set; }
    public QueryRequestHandler(IBaseRepositoryProvider<TEntity> baseRepositoryProvider)
    {
        BaseRepositoryProvider = baseRepositoryProvider;
    }
    public async Task<QueryResponse<TEntity>> Handle(QueryRequest<TEntity> request, CancellationToken cancellationToken)
    {
        if(request.Keys?.Count()>0)
        {
            return await Task.FromResult(new QueryResponse<TEntity>(BaseRepositoryProvider.GetAllItemByList(request.Keys).AsQueryable()));
        }
        if (request.FilterExpression != null)
        {
            return await Task.FromResult(new QueryResponse<TEntity>(BaseRepositoryProvider.FindAsync(request.FilterExpression).Result.AsQueryable()));
        }
        else
        {
            return await Task.FromResult(new QueryResponse<TEntity>(BaseRepositoryProvider.GetAllWithInclude().Result.AsQueryable()));
        }
    }
}