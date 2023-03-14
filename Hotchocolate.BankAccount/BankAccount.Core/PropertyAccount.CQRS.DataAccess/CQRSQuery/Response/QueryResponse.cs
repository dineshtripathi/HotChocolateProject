
namespace PropertyAccount.CQRS.DataAccess.CQRSQuery.Response;

public class QueryResponse<T>
{

    public IQueryable<T>? Loads { get; set; }

    public QueryResponse(IQueryable<T>? results)
    {
        Loads = results;
    }

    public T? Load { get; set; }

    public QueryResponse(T? result)
    {
        Load = result;
    }
}