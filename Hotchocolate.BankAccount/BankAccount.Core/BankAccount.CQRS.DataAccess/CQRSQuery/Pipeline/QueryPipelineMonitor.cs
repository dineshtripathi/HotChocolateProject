using MediatR;

namespace BankAccount.CQRS.DataAccess.CQRSQuery.Pipeline;

public class QueryPipelineMonitor<T> : IPipelineBehavior<QueryRequest<T>, QueryResponse<T>>
{


    public async Task<QueryResponse<T>> Handle(QueryRequest<T> request, RequestHandlerDelegate<QueryResponse<T>> next, CancellationToken cancellationToken)
    {
        // Do something before the request is handled by the handlers
        var response = await next();
        // Do something after the request is handled by the handlers
        return response;
    }
}