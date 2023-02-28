using BankAccount.DatabaseEntity.DBContext.BaseRepositoryProvider;
using MediatR;

public class QueryRequestHandler<T> : IRequestHandler<QueryRequest<T>, QueryResponse<T>>
{
    private IBaseRepositoryProvider<T> _baseRepositoryProvider { get; set; }
    public QueryRequestHandler(IBaseRepositoryProvider<T> baseRepositoryProvider)
    {
        _baseRepositoryProvider = baseRepositoryProvider;
    }
    public async Task<QueryResponse<T>> Handle(QueryRequest<T> request, CancellationToken cancellationToken)
    {
        if(request.Keys?.Count()>0)
        {
            return await Task.FromResult(new QueryResponse<T>(_baseRepositoryProvider.GetAllItemByList(request.Keys).AsQueryable()));
        }
        if (request.FilterExpression != null)
        {
            return await Task.FromResult(new QueryResponse<T>(_baseRepositoryProvider.FindAsync(request.FilterExpression).Result.AsQueryable()));
        }
        else
        {
            return await Task.FromResult(new QueryResponse<T>(_baseRepositoryProvider.GetAllWithInclude().Result.AsQueryable()));
        }
    }
}
