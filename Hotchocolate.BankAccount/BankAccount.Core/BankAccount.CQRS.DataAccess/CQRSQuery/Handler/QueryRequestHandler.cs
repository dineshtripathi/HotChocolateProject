using BankAccount.CQRS.DataAccess.CQRSQuery.Request;
using BankAccount.CQRS.DataAccess.CQRSQuery.Response;
using BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;
using MediatR;

namespace BankAccount.CQRS.DataAccess.CQRSQuery.Handler;

public class QueryRequestHandler<T> : IRequestHandler<QueryRequest<T>, QueryResponse<T>>
{
    private IBaseRepositoryProvider<T> BaseRepositoryProvider { get; set; }
    public QueryRequestHandler(IBaseRepositoryProvider<T> baseRepositoryProvider)
    {
        BaseRepositoryProvider = baseRepositoryProvider;
    }
    public async Task<QueryResponse<T>> Handle(QueryRequest<T> request, CancellationToken cancellationToken)
    {
        if(request.Keys?.Count()>0)
        {
            return await Task.FromResult(new QueryResponse<T>(BaseRepositoryProvider.GetAllItemByList(request.Keys).AsQueryable()));
        }
        if (request.FilterExpression != null)
        {
            return await Task.FromResult(new QueryResponse<T>(BaseRepositoryProvider.FindAsync(request.FilterExpression).Result.AsQueryable()));
        }
        else
        {
            return await Task.FromResult(new QueryResponse<T>(BaseRepositoryProvider.GetAllWithInclude().Result.AsQueryable()));
        }
    }
}