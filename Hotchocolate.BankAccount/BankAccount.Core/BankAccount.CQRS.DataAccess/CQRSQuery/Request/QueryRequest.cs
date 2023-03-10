using System.Linq.Expressions;
using BankAccount.CQRS.DataAccess.CQRSQuery.Response;
using MediatR;

namespace BankAccount.CQRS.DataAccess.CQRSQuery.Request;

public class QueryRequest<T> : IRequest<QueryResponse<T>>
{
    public IQueryable<T>? Items { get; set; }
    public IReadOnlyList<string>? Keys { get; set; }
    public T? Item { get; set; }
    public Expression<Func<T, bool>>? FilterExpression { get; set; }
    public EnumQueryReturnObjectType ReturnType { get; set; }
}